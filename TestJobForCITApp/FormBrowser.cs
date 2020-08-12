using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using CefSharp;
using CefSharp.Example.Handlers;
using CefSharp.WinForms;
using Spire.Pdf;

namespace TestJobForCITApp
{
    public partial class FormBrowser : Form
    {
        public ChromiumWebBrowser chromeBrowser;
        private Uri _uri;
        private List<string> _listFiles;
        public FormBrowser(Uri uri, List<string> listFiles)
        {
            _uri = uri;
            _listFiles = listFiles;
            InitializeComponent();
            InitializeChromium();
        }
        public void InitializeChromium()
        {
            chromeBrowser = new ChromiumWebBrowser();
            chromeBrowser.DownloadHandler = new DownloadHandler();
            chromeBrowser.IsBrowserInitializedChanged += ChromeBrowser_IsBrowserInitializedChanged;
            chromeBrowser.Load(_uri.ToString());
            this.Controls.Add(chromeBrowser);
            chromeBrowser.Dock = DockStyle.Fill;
        }

        private void ChromeBrowser_IsBrowserInitializedChanged(object sender, EventArgs e)
        {
            
        }

        private void FormBrowser_FormClosing(object sender, FormClosingEventArgs e)
        {
            chromeBrowser.Dispose();
        }

        private void печатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //chromeBrowser.Print();
            chromeBrowser.PrintToPdfAsync(@"C:\Users\Alex\source\repos\TestJobForCITApp\TestJobForCITApp\bin\Debug\temp\1.pdf");
        }

        private void печатьToolStripMenuItem1_Click(object sender, EventArgs e)
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
            chromeBrowser.PrintToPdfAsync(outputPDF);
            //Собираем все PDF в один
            String[] pathsOutPdfs = Directory.GetFiles(targetLocation);
            PdfDocument[] OutPdfs = new PdfDocument[pathsOutPdfs.Length];
            PdfDocument AllInOnePdf = new PdfDocument(outputPDF);
            for (int i = 0; i < pathsOutPdfs.Length; i++)
            {
                OutPdfs[i] = new PdfDocument(pathsOutPdfs[i]);
            }
            for (int i = 0; i < pathsOutPdfs.Length; i++)
            {
                AllInOnePdf.AppendPage(OutPdfs[i]);
            }
            AllInOnePdf.SaveToFile(outputPDF);




            chromeBrowser.Load(outputPDF);
        }
    }
}
