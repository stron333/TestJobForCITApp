using System;
using System.Drawing.Printing;
using System.Windows.Forms;
using Spire.Pdf;
using System.Collections.Generic;


namespace TestJobForCITApp
{
    public partial class FormPrintDialogForPdf : Form
    {
        private PdfDocument _document;

        public FormPrintDialogForPdf(PdfDocument document)
        {
            InitializeComponent();
            _document = document;
            List<string> printersList = new List<string>();
            PrinterSettings.StringCollection sc = PrinterSettings.InstalledPrinters;
            foreach (string printerName in sc)
            {
                printersList.Add(printerName);
            }
            comboBoxPrintersList.DataSource = printersList;

            if (_document.Pages.Count <= 1)
            {
                radioButtonRange.Enabled = false;
            }
        }

        

        private void radioButtonRange_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonRange.Checked)
            {
                numericUpDownFrom.Enabled = true;
                numericUpDownTo.Enabled = true;
                numericUpDownFrom.Value = 1;
                numericUpDownTo.Value = _document.Pages.Count;
                numericUpDownFrom.Minimum = 1;
                numericUpDownTo.Minimum = 2;
                numericUpDownFrom.Maximum = _document.Pages.Count - 1;
                numericUpDownTo.Maximum = _document.Pages.Count;
                _document.PrintFromPage = 1;
                _document.PrintToPage = _document.Pages.Count;
            }
            else
            {
                numericUpDownFrom.Enabled = false;
                numericUpDownTo.Enabled = false;
                numericUpDownFrom.Text = "";
                numericUpDownTo.Text = "";
            }
        }

 



        private void comboBoxSheetsPerList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxSheetsPerList.SelectedIndex == 5)
            {
                numericUpDownRows.Enabled = true;
                numericUpDownColumns.Enabled = true;
                numericUpDownRows.Text = "1";
                numericUpDownColumns.Text = "1";
                _document.PrintSettings.SelectMultiPageLayout(
                    Convert.ToInt32(numericUpDownRows.Text),
                    Convert.ToInt32(numericUpDownColumns.Text));
            }
            else
            {
                numericUpDownRows.Enabled = false;
                numericUpDownColumns.Enabled = false;
                numericUpDownRows.Text = "";
                numericUpDownColumns.Text = "";
                _document.PrintSettings.SelectMultiPageLayout(
                    1,
                    1);
            }

            switch (comboBoxSheetsPerList.SelectedIndex)
            {
                case 0:
                {
                    _document.PrintSettings.Landscape = radioButtonLandscape.Checked;
                    _document.PrintSettings.SelectMultiPageLayout(
                        Convert.ToInt32(1),
                        Convert.ToInt32(1));
                }
                    break;
                case 1:
                {
                    _document.PrintSettings.Landscape = true;
                    _document.PrintSettings.SelectMultiPageLayout(
                        Convert.ToInt32(1),
                        Convert.ToInt32(2));
                    }
                    break;
                case 2:
                {
                    _document.PrintSettings.Landscape = false;
                    _document.PrintSettings.SelectMultiPageLayout(
                        Convert.ToInt32(2),
                        Convert.ToInt32(2));
                }
                    break;
                case 3:
                {
                    _document.PrintSettings.Landscape = true;
                    _document.PrintSettings.SelectMultiPageLayout(
                        Convert.ToInt32(2),
                        Convert.ToInt32(3));
                }
                    break;
                case 4:
                {
                    _document.PrintSettings.Landscape = false;
                    _document.PrintSettings.SelectMultiPageLayout(
                        Convert.ToInt32(3),
                        Convert.ToInt32(3));
                }
                    break;

            }
        }

        private void comboBoxPrintersList_SelectedIndexChanged(object sender, EventArgs e)
        {
            _document.PrintSettings.PrinterName = comboBoxPrintersList.SelectedItem.ToString();
        }

        private void numericUpDownCopies_ValueChanged(object sender, EventArgs e)
        {
            _document.PrintSettings.Copies = Convert.ToInt16(numericUpDownCopies.Value);
        }

        private void numericUpDownFrom_ValueChanged(object sender, EventArgs e)
        {
            _document.PrintFromPage = Convert.ToInt32(numericUpDownFrom.Value);
        }

        private void numericUpDownTo_ValueChanged(object sender, EventArgs e)
        {
            _document.PrintToPage = Convert.ToInt32(numericUpDownTo.Value);
        }

        private void radioButtonAllPage_CheckedChanged(object sender, EventArgs e)
        {
            _document.PrintFromPage = 1;
            _document.PrintToPage = _document.Pages.Count;
        }



        private void radioButtonLandscape_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonLandscape.Checked)
                _document.PrintSettings.Landscape = true;
            else
            {
                _document.PrintSettings.Landscape = false;
            }

        }

        private void распечататьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _document.Print();
        }

        private void предварительынйПросмотрToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPrintPreview formPrintPreview = new FormPrintPreview(_document);
            formPrintPreview.ShowDialog();
        }
    }
}
