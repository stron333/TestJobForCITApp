using System.Windows.Forms;
using Spire.Pdf;

namespace TestJobForCITApp
{
    public partial class FormPrintDialogForPdf : Form
    {
        private PdfDocument _document;
        public FormPrintDialogForPdf(PdfDocument document)
        {
            InitializeComponent();
            _document = document;
        }
    }
}
