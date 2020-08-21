using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
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
        public FormAwesomium(Uri uri, List<string> listFiles)
        {
            InitializeComponent();
            _uri = uri;
            webControl1.Source = _uri;
            _listFiles = listFiles;
        }

        private void печатьToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string targetLocation = Directory.GetCurrentDirectory() + @"\temp";
            string outputPDF = Directory.GetCurrentDirectory() + @"\AllInOne.pdf";
            //удаляем временные файлы
            if (Directory.Exists(targetLocation))
                Directory.Delete(targetLocation, true);
            Directory.CreateDirectory(targetLocation);
            //Конвертируем файлы вложений в PDF
            FileHelper fileHelper = new FileHelper();
            foreach (string filePath in _listFiles)
            {
                FileInfo file = new FileInfo(filePath);
                var fileName = file.Name;
                var sourceFilePath = file.FullName;
                string contentType = MimeMapping.MimeUtility.GetMimeMapping(file.ToString());
                fileHelper.ConvertToPDF(sourceFilePath, contentType, fileName, targetLocation);
            }

            //Конвертируем XML в PDF
            webControl1.PrintToFile(targetLocation, PrintConfig.Default);
            //Собираем все PDF в один
            String[] pathsOutPdfs = Directory.GetFiles(targetLocation);
            PdfDocument[] OutPdfs = new PdfDocument[pathsOutPdfs.Length];
            PdfDocument AllInOnePdf = new PdfDocument();
            for (int i = 0; i < pathsOutPdfs.Length; i++)
            {
                OutPdfs[i] = new PdfDocument(pathsOutPdfs[i]);
            }
            for (int i = 0; i < pathsOutPdfs.Length; i++)
            {
                AllInOnePdf.AppendPage(OutPdfs[i]);
            }

            PrintDialog dialogPrint = new PrintDialog();
            if (dialogPrint.ShowDialog() == DialogResult.OK)
            {
                //Set the pagenumber which you choose as the start page to print
                AllInOnePdf.PrintFromPage = dialogPrint.PrinterSettings.FromPage;
                //Set the pagenumber which you choose as the final page to print
                AllInOnePdf.PrintToPage = dialogPrint.PrinterSettings.ToPage;
                //Set the name of the printer which is to print the PDF
                AllInOnePdf.PrinterName = dialogPrint.PrinterSettings.PrinterName;

                PrintDocument printDoc = AllInOnePdf.PrintDocument;

                dialogPrint.Document = printDoc;
                printDoc.Print();
            }
        }
    }
}
