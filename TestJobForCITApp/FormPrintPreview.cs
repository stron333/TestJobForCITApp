using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Spire.Pdf;

namespace TestJobForCITApp
{
    public partial class FormPrintPreview : Form
    {
        private PdfDocument _document;

        public FormPrintPreview(PdfDocument document, int CountOfPages)
        {
            InitializeComponent();
            _document = document;
            _document.Preview(printPreviewControl1);
            /*Stream[] streamPdf = _document.SaveToStream(FileFormat.PDF);
            pdfDocumentViewer1.LoadFromStream(streamPdf[0]);
            pdfDocumentViewer1.PrintSettings.Copies = document.PrintSettings.Copies;
            pdfDocumentViewer1.PrintSettings.Landscape = document.PrintSettings.Landscape;
            pdfDocumentViewer1.PrintSettings.SelectPageRange(
                _document.PrintSettings.PrintFromPage, 
                _document.PrintSettings.PrintToPage);*/
            if (CountOfPages == 1)
                printPreviewControl1.Columns = 1;
            else
            {
                printPreviewControl1.Columns = 2;
            }
            printPreviewControl1.Rows = CountOfPages / 2+1;



        }                                                                                                                                                                                                                                                                                                       

        private void печатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                _document.Print();
            }
            catch (Exception exception)
            {
               
            }
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
