using System;
using System.Collections.Generic;
using System.IO;
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
        public FormAwesomium(Uri uri, List<string> listFiles)
        {
            InitializeComponent();
            _uri = uri;
            webControl1.Source = _uri;
            _listFiles = listFiles;
            tempLocation = Directory.GetCurrentDirectory() + @"\temp";
            var temp = "";
        }

        private void печатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //удаляем временные файлы
            if (Directory.Exists(tempLocation))
                Directory.Delete(tempLocation, true);
            Directory.CreateDirectory(tempLocation);

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
            webControl1.PrintToFile(tempLocation, PrintConfig.Default);
            webControl1.PrintComplete += WebControl1OnPrintComplete;
        }



        private void WebControl1OnPrintComplete(object sender, PrintCompleteEventArgs e)
        {
            PrintAllInOnePDF();
        }



        private void PrintAllInOnePDF()
        {
            //Собираем все PDF в один
            webControl1.PrintComplete -= WebControl1OnPrintComplete;
            PdfDocument AllInOnePdf = UniteAllPdfInOne();
            using (FormPrintDialogForPdf dialogForPdf = new FormPrintDialogForPdf(AllInOnePdf))
            {
                dialogForPdf.ShowDialog();
            }
        }
        private PdfDocument UniteAllPdfInOne()
        {
            //Конвертируем XML в PDF
            String[] pathsOutPdfs = Directory.GetFiles(tempLocation);
            List<PdfDocument> OutPdfs = new List<PdfDocument>();
            PdfDocument AllInOnePdf = new PdfDocument(pathsOutPdfs[0]);
            for (int i = 1; i < pathsOutPdfs.Length; i++)
            {
                OutPdfs.Add(new PdfDocument(pathsOutPdfs[i]));
            }
            for (int i = 0; i < OutPdfs.Count; i++)
            {
                AllInOnePdf.AppendPage(OutPdfs[i]);
            }

            return AllInOnePdf;
        }
    }
}
