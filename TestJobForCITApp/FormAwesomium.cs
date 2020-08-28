using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Awesomium.Core;
using Spire.Pdf;

namespace TestJobForCITApp
{
    public partial class FormAwesomium : Form
    {
        private Uri _uri;
        private List<string> _listFiles;
        private string tempLocation;
        private PdfDocument _AllInOnePdf;
        public FormAwesomium(Uri uri, List<string> listFiles)
        {
            InitializeComponent();
            _uri = uri;
            webControl1.Source = _uri;
            _listFiles = listFiles;
            tempLocation = Directory.GetCurrentDirectory() + @"\temp";
        }


        private void MakeAllInOnePdf()
        {
            if (Directory.Exists(tempLocation))
                Directory.Delete(tempLocation, true);
            Directory.CreateDirectory(tempLocation + "\\allInOne");

            //Конвертируем файлы вложений в PDF
            FileHelper fileHelper = new FileHelper();
            foreach (string filePath in _listFiles)
            {
                FileInfo file = new FileInfo(filePath);
                var fileName = file.Name;
                var sourceFilePath = file.FullName;
                string contentType = MimeMapping.MimeUtility.GetMimeMapping(file.ToString());
                fileHelper.ConvertToPDF(sourceFilePath, contentType, fileName, tempLocation);
            }
            //Конвертируем XML в PDF
            webControl1.PrintComplete += WebControl1OnPrintComplete;
            webControl1.PrintToFile(tempLocation + "\\allInOne", PrintConfig.Default);
            _AllInOnePdf = UniteAllPdfInOne();
        }
        private void WebControl1OnPrintComplete(object sender, PrintCompleteEventArgs e)
        {
            webControl1.PrintComplete -= WebControl1OnPrintComplete;
        }
       
        private PdfDocument UniteAllPdfInOne()
        {
            while (true)
            {
                string [] files = Directory.GetFiles(tempLocation + "\\allInOne");
                if (files.Length != 0)
                {
                    break;
                }
            }
            //Конвертируем XML в PDF
            String[] pathsOutPdfs = Directory.GetFiles(tempLocation);
            List<PdfDocument> OutPdfs = new List<PdfDocument>();
            PdfDocument AllInOnePdf = new PdfDocument(Directory.GetFiles(tempLocation + "\\allInOne")[0]);
            for (int i = 0; i < pathsOutPdfs.Length; i++)
            {
                OutPdfs.Add(new PdfDocument(pathsOutPdfs[i]));
            }
            for (int i = 0; i < OutPdfs.Count; i++)
            {
                AllInOnePdf.AppendPage(OutPdfs[i]);
            }
            return AllInOnePdf;
        }

        private void печатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_AllInOnePdf == null)
                MakeAllInOnePdf();
            using (FormPrintDialogForPdf dialogForPdf = new FormPrintDialogForPdf(_AllInOnePdf))
            {
                dialogForPdf.ShowDialog();
            }
        }

        private void сохранитьВPDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_AllInOnePdf == null)
                MakeAllInOnePdf();
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Pdf Files|*.pdf";
            if (dialog.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = dialog.FileName;
            _AllInOnePdf.SaveToFile(filename);
        }

        
        private void сохранитьXMLToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "XML Files (*.xml)|*.xml";
            if (dialog.ShowDialog() == DialogResult.Cancel)
                return;
            File.Copy(_uri.LocalPath, dialog.FileName, true);
        }
    }
}
