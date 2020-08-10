using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.Example;
using CefSharp.Example.Handlers;
using CefSharp.WinForms;

namespace TestJobForCITApp
{
    public partial class FormBrowser : Form
    {
        public ChromiumWebBrowser chromeBrowser;
        private Uri _uri;
        public FormBrowser(Uri uri)
        {
            InitializeComponent();
            _uri = uri;
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
            chromeBrowser.Print();
            PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.Document = 
                new PrintDocument();
        }

        private void печатьВложенийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintDocument printDocument = new PrintDocument();
            printDocument.Container.Add();
        }
    }
}
