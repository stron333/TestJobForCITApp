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

        public FormPrintPreview(PdfDocument document)
        {
            InitializeComponent();
            _document = document;
            //_document.Preview(pdfDocumentViewer1);
            Stream[] streamPdf = _document.SaveToStream(FileFormat.PDF);
            pdfDocumentViewer1.LoadFromStream(streamPdf[0]);
            //pdfDocumentViewer1.PrintSettings.
        }                                                                                                                                                                                                                                                                                                       

        private void печатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _document.Print();
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
