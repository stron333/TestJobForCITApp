using System;
using System.Drawing.Printing;
using System.Windows.Forms;
using Spire.Pdf;
using System.Collections.Generic;
using System.IO;


namespace TestJobForCITApp
{
    public partial class FormPrintDialogForPdf : Form
    {
        private PdfDocument _document;

        public FormPrintDialogForPdf(PdfDocument document)
        {
            InitializeComponent();
            /*document.SaveToFile(Directory.GetCurrentDirectory()+"\\temp.pdf", FileFormat.PDF);
            _document = new PdfDocument(Directory.GetCurrentDirectory() + "\\temp.pdf");
            File.Delete(Directory.GetCurrentDirectory() + "\\temp.pdf");            */
            _document = document;
            List<string> printersList = new List<string>();
            PrinterSettings.StringCollection sc = PrinterSettings.InstalledPrinters;
            PrinterSettings settings = new PrinterSettings();
            string defaultPrinterName = settings.PrinterName;
            foreach (string printerName in sc)
            {
                printersList.Add(printerName);
            }
            comboBoxPrintersList.DataSource = printersList;
            comboBoxPrintersList.SelectedItem = defaultPrinterName;
            if (_document.PrintSettings.Landscape)
            {
                radioButtonLandscape.Checked = true;
                radioButtonPortrait.Checked = false;
            }
            else
            {
                radioButtonLandscape.Checked = false;
                radioButtonPortrait.Checked = true;
            }
            
            if (_document.Pages.Count <= 1)
            {
                radioButtonRange.Enabled = false;
            }
            _document.PrintSettings.SelectPageRange(1, _document.Pages.Count);
            comboBoxSheetsPerList.SelectedIndex = 0;
            
        }

        

        private void radioButtonRange_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonRange.Checked)
            {
                numericUpDownFrom.Enabled = true;
                numericUpDownTo.Enabled = true;
                numericUpDownFrom.Value = 1;
                numericUpDownTo.Value = _document.Pages.Count;
                numericUpDownFrom.Text = "1";
                numericUpDownTo.Text = _document.Pages.Count.ToString();
                numericUpDownFrom.Minimum = 1;
                numericUpDownTo.Minimum = 1;
                numericUpDownFrom.Maximum = _document.Pages.Count;
                numericUpDownTo.Maximum = _document.Pages.Count;
                _document.PrintSettings.SelectPageRange((int)numericUpDownFrom.Value, (int)numericUpDownTo.Value);
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
            int rows=1;
            int columns=1;
            if (comboBoxSheetsPerList.SelectedIndex == 5)
            {
                numericUpDownRows.Enabled = true;
                numericUpDownColumns.Enabled = true;
            }
            else
            {
                numericUpDownRows.Enabled = false;
                numericUpDownColumns.Enabled = false;
                numericUpDownRows.Text = "";
                numericUpDownColumns.Text = "";
            }

            switch (comboBoxSheetsPerList.SelectedIndex)
            {
                case 0:
                {
                    _document.PrintSettings.Landscape = false;
                    rows = 1;
                    columns = 1;
                }
                    break;
                case 1:
                {
                    _document.PrintSettings.Landscape = true;
                    rows = 1;
                    columns = 2;
                    }
                    break;
                case 2:
                {
                    _document.PrintSettings.Landscape = false;
                    rows = 2;
                    columns = 2;
                    }
                    break;
                case 3:
                {
                    _document.PrintSettings.Landscape = true;
                    rows = 2;
                    columns = 3;
                    }
                    break;
                case 4:
                {
                    _document.PrintSettings.Landscape = false;
                    rows = 3;
                    columns = 3;
                }
                    break;
            }
            numericUpDownRows.Text = rows.ToString();
            numericUpDownColumns.Text = columns.ToString();
            radioButtonLandscape.Checked = _document.PrintSettings.Landscape;
            
        }

        private void numericUpDownRows_ValueChanged(object sender, EventArgs e)
        {
            _document.PrintSettings.SelectMultiPageLayout(
                (int)numericUpDownRows.Value,
                (int)numericUpDownColumns.Value);
            

        }

        private void comboBoxPrintersList_SelectedIndexChanged(object sender, EventArgs e)
        {
            _document.PrintSettings.PrinterName = comboBoxPrintersList.SelectedItem.ToString();
        }

        private void numericUpDownCopies_ValueChanged(object sender, EventArgs e)
        {
            _document.PrintSettings.Copies = Convert.ToInt16(numericUpDownCopies.Value);
        }

        private void numericUpDownRange_ValueChanged(object sender, EventArgs e)
        {
            numericUpDownTo.Minimum = (int) numericUpDownFrom.Value;
            numericUpDownFrom.Maximum = (int)numericUpDownTo.Value;
            _document.PrintSettings.SelectPageRange((int)numericUpDownFrom.Value, (int)numericUpDownTo.Value);
            

        }



        private void radioButtonAllPage_CheckedChanged(object sender, EventArgs e)
        {
            _document.PrintSettings.SelectPageRange(1, _document.Pages.Count);
        }



        private void radioButtonLandscape_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonLandscape.Checked)
                _document.PrintSettings.Landscape = true;
            else
            {
                _document.PrintSettings.Landscape = false;
            }

            radioButtonPortrait.Checked = !radioButtonLandscape.Checked;
            
        }

        private void распечататьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                _document.Print();
            }
            catch (Exception exception)
            {
                
            }
        }

        private void предварительынйПросмотрToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int countOfPage = Convert.ToInt32(_document.PrintSettings.PrintToPage
                               - _document.PrintSettings.PrintFromPage
                               + 1)
                              / ((int)numericUpDownRows.Value*(int)numericUpDownColumns.Value);
            FormPrintPreview formPrintPreview = new FormPrintPreview(_document, countOfPage);
            formPrintPreview.ShowDialog();
        }

        
    }
}
