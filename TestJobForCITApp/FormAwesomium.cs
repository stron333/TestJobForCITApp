using System;
using System.Collections.Generic;
using System.Drawing.Printing;
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
        public FormAwesomium(Uri uri, List<string> listFiles)
        {
            InitializeComponent();
            _uri = uri;
            webControl1.Source = _uri;
            _listFiles = listFiles;
        }

        private void печатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printPreviewControl1.Visible = true;
            printPreviewControl1.Dock = DockStyle.Fill;
            string targetLocation = Directory.GetCurrentDirectory() + @"\temp";
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
            webControl1.PrintComplete += (o, args) => 
            {
                //Собираем все PDF в один

                PdfDocument AllInOnePdf = UniteAllPdfInOne(targetLocation);
                AllInOnePdf.PrintSettings.SelectMultiPageLayout(1, 2);
                AllInOnePdf.PrintSettings.Landscape = true;
                AllInOnePdf.Preview(this.printPreviewControl1);

                PrintDialog dialogPrint = new PrintDialog();
                /*if (dialogPrint.ShowDialog() == DialogResult.OK)
                {
                    AllInOnePdf.PrintFromPage = dialogPrint.PrinterSettings.FromPage;
                    AllInOnePdf.PrintToPage = dialogPrint.PrinterSettings.ToPage;
                    AllInOnePdf.PrinterName = dialogPrint.PrinterSettings.PrinterName;
                    

                    PrintDocument printDoc = AllInOnePdf.PrintDocument;
                    dialogPrint.Document = printDoc;
                    printDoc.Print();
                }*/
            };
        }

        private PdfDocument UniteAllPdfInOne(string targetLocation)
        {
            //Конвертируем XML в PDF
            String[] pathsOutPdfs = Directory.GetFiles(targetLocation);
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
