using System;
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
            if (CountOfPages == 1)
                printPreviewControl1.Columns = 1;
            else
            {
                printPreviewControl1.Columns = 2;
            }
            printPreviewControl1.Rows = (int)Math.Ceiling(CountOfPages / 2.0);
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

        private void FormPrintPreview_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void сохранитьВPDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
    }
}
