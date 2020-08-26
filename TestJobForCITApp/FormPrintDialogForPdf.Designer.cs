namespace TestJobForCITApp
{
    partial class FormPrintDialogForPdf
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBoxPrintersList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownCopies = new System.Windows.Forms.NumericUpDown();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.numericUpDownTo = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownFrom = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.radioButtonRange = new System.Windows.Forms.RadioButton();
            this.radioButtonAllPage = new System.Windows.Forms.RadioButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.numericUpDownColumns = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownRows = new System.Windows.Forms.NumericUpDown();
            this.labelx = new System.Windows.Forms.Label();
            this.comboBoxSheetsPerList = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.radioButtonLandscape = new System.Windows.Forms.RadioButton();
            this.radioButtonPortrait = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.распечататьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.предварительынйПросмотрToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отменаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pdfDocumentViewer1 = new Spire.PdfViewer.Forms.PdfDocumentViewer();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCopies)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFrom)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownColumns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRows)).BeginInit();
            this.panel5.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxPrintersList
            // 
            this.comboBoxPrintersList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPrintersList.FormattingEnabled = true;
            this.comboBoxPrintersList.Location = new System.Drawing.Point(77, 3);
            this.comboBoxPrintersList.Name = "comboBoxPrintersList";
            this.comboBoxPrintersList.Size = new System.Drawing.Size(297, 21);
            this.comboBoxPrintersList.TabIndex = 0;
            this.comboBoxPrintersList.SelectedIndexChanged += new System.EventHandler(this.comboBoxPrintersList_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(5, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Принтер";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Копий:";
            // 
            // numericUpDownCopies
            // 
            this.numericUpDownCopies.Location = new System.Drawing.Point(52, 36);
            this.numericUpDownCopies.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownCopies.Name = "numericUpDownCopies";
            this.numericUpDownCopies.ReadOnly = true;
            this.numericUpDownCopies.Size = new System.Drawing.Size(38, 20);
            this.numericUpDownCopies.TabIndex = 3;
            this.numericUpDownCopies.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownCopies.ValueChanged += new System.EventHandler(this.numericUpDownCopies_ValueChanged);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.comboBoxPrintersList);
            this.panel1.Controls.Add(this.numericUpDownCopies);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(396, 68);
            this.panel1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.numericUpDownTo);
            this.panel2.Controls.Add(this.numericUpDownFrom);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.radioButtonRange);
            this.panel2.Controls.Add(this.radioButtonAllPage);
            this.panel2.Location = new System.Drawing.Point(3, 77);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(396, 92);
            this.panel2.TabIndex = 5;
            // 
            // numericUpDownTo
            // 
            this.numericUpDownTo.Enabled = false;
            this.numericUpDownTo.Location = new System.Drawing.Point(168, 59);
            this.numericUpDownTo.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownTo.Name = "numericUpDownTo";
            this.numericUpDownTo.ReadOnly = true;
            this.numericUpDownTo.Size = new System.Drawing.Size(38, 20);
            this.numericUpDownTo.TabIndex = 8;
            this.numericUpDownTo.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownTo.ValueChanged += new System.EventHandler(this.numericUpDownRange_ValueChanged);
            // 
            // numericUpDownFrom
            // 
            this.numericUpDownFrom.Enabled = false;
            this.numericUpDownFrom.Location = new System.Drawing.Point(99, 59);
            this.numericUpDownFrom.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownFrom.Name = "numericUpDownFrom";
            this.numericUpDownFrom.ReadOnly = true;
            this.numericUpDownFrom.Size = new System.Drawing.Size(38, 20);
            this.numericUpDownFrom.TabIndex = 4;
            this.numericUpDownFrom.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownFrom.ValueChanged += new System.EventHandler(this.numericUpDownRange_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(143, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "по";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(84, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "c";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(5, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Страницы для печати";
            // 
            // radioButtonRange
            // 
            this.radioButtonRange.AutoSize = true;
            this.radioButtonRange.Location = new System.Drawing.Point(8, 59);
            this.radioButtonRange.Name = "radioButtonRange";
            this.radioButtonRange.Size = new System.Drawing.Size(76, 17);
            this.radioButtonRange.TabIndex = 1;
            this.radioButtonRange.Text = "Диапозон";
            this.radioButtonRange.UseVisualStyleBackColor = true;
            this.radioButtonRange.CheckedChanged += new System.EventHandler(this.radioButtonRange_CheckedChanged);
            // 
            // radioButtonAllPage
            // 
            this.radioButtonAllPage.AutoSize = true;
            this.radioButtonAllPage.Checked = true;
            this.radioButtonAllPage.Location = new System.Drawing.Point(8, 36);
            this.radioButtonAllPage.Name = "radioButtonAllPage";
            this.radioButtonAllPage.Size = new System.Drawing.Size(44, 17);
            this.radioButtonAllPage.TabIndex = 0;
            this.radioButtonAllPage.TabStop = true;
            this.radioButtonAllPage.Text = "Все";
            this.radioButtonAllPage.UseVisualStyleBackColor = true;
            this.radioButtonAllPage.CheckedChanged += new System.EventHandler(this.radioButtonAllPage_CheckedChanged);
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.numericUpDownColumns);
            this.panel4.Controls.Add(this.numericUpDownRows);
            this.panel4.Controls.Add(this.labelx);
            this.panel4.Controls.Add(this.comboBoxSheetsPerList);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Location = new System.Drawing.Point(3, 175);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(396, 40);
            this.panel4.TabIndex = 8;
            // 
            // numericUpDownColumns
            // 
            this.numericUpDownColumns.Enabled = false;
            this.numericUpDownColumns.Location = new System.Drawing.Point(290, 7);
            this.numericUpDownColumns.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownColumns.Name = "numericUpDownColumns";
            this.numericUpDownColumns.ReadOnly = true;
            this.numericUpDownColumns.Size = new System.Drawing.Size(38, 20);
            this.numericUpDownColumns.TabIndex = 9;
            this.numericUpDownColumns.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownColumns.ValueChanged += new System.EventHandler(this.numericUpDownRows_ValueChanged);
            // 
            // numericUpDownRows
            // 
            this.numericUpDownRows.Enabled = false;
            this.numericUpDownRows.Location = new System.Drawing.Point(228, 7);
            this.numericUpDownRows.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownRows.Name = "numericUpDownRows";
            this.numericUpDownRows.ReadOnly = true;
            this.numericUpDownRows.Size = new System.Drawing.Size(38, 20);
            this.numericUpDownRows.TabIndex = 9;
            this.numericUpDownRows.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownRows.ValueChanged += new System.EventHandler(this.numericUpDownRows_ValueChanged);
            // 
            // labelx
            // 
            this.labelx.AutoSize = true;
            this.labelx.Location = new System.Drawing.Point(272, 9);
            this.labelx.Name = "labelx";
            this.labelx.Size = new System.Drawing.Size(12, 13);
            this.labelx.TabIndex = 4;
            this.labelx.Text = "x";
            // 
            // comboBoxSheetsPerList
            // 
            this.comboBoxSheetsPerList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSheetsPerList.FormattingEnabled = true;
            this.comboBoxSheetsPerList.Items.AddRange(new object[] {
            "1",
            "2",
            "4",
            "6",
            "9",
            "Задать..."});
            this.comboBoxSheetsPerList.Location = new System.Drawing.Point(127, 6);
            this.comboBoxSheetsPerList.Name = "comboBoxSheetsPerList";
            this.comboBoxSheetsPerList.Size = new System.Drawing.Size(95, 21);
            this.comboBoxSheetsPerList.TabIndex = 1;
            this.comboBoxSheetsPerList.SelectedIndexChanged += new System.EventHandler(this.comboBoxSheetsPerList_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(5, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Страниц на листе:";
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.radioButtonLandscape);
            this.panel5.Controls.Add(this.radioButtonPortrait);
            this.panel5.Controls.Add(this.label8);
            this.panel5.Location = new System.Drawing.Point(3, 221);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(396, 71);
            this.panel5.TabIndex = 9;
            // 
            // radioButtonLandscape
            // 
            this.radioButtonLandscape.AutoSize = true;
            this.radioButtonLandscape.Location = new System.Drawing.Point(99, 36);
            this.radioButtonLandscape.Name = "radioButtonLandscape";
            this.radioButtonLandscape.Size = new System.Drawing.Size(82, 17);
            this.radioButtonLandscape.TabIndex = 2;
            this.radioButtonLandscape.TabStop = true;
            this.radioButtonLandscape.Text = "Альбомная";
            this.radioButtonLandscape.UseVisualStyleBackColor = true;
            this.radioButtonLandscape.CheckedChanged += new System.EventHandler(this.radioButtonLandscape_CheckedChanged);
            // 
            // radioButtonPortrait
            // 
            this.radioButtonPortrait.AutoSize = true;
            this.radioButtonPortrait.Location = new System.Drawing.Point(8, 36);
            this.radioButtonPortrait.Name = "radioButtonPortrait";
            this.radioButtonPortrait.Size = new System.Drawing.Size(85, 17);
            this.radioButtonPortrait.TabIndex = 1;
            this.radioButtonPortrait.TabStop = true;
            this.radioButtonPortrait.Text = "Портретная";
            this.radioButtonPortrait.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(5, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Ориентация:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.распечататьToolStripMenuItem,
            this.предварительынйПросмотрToolStripMenuItem,
            this.отменаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(428, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // распечататьToolStripMenuItem
            // 
            this.распечататьToolStripMenuItem.Name = "распечататьToolStripMenuItem";
            this.распечататьToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.распечататьToolStripMenuItem.Text = "Распечатать";
            this.распечататьToolStripMenuItem.Click += new System.EventHandler(this.распечататьToolStripMenuItem_Click);
            // 
            // предварительынйПросмотрToolStripMenuItem
            // 
            this.предварительынйПросмотрToolStripMenuItem.Name = "предварительынйПросмотрToolStripMenuItem";
            this.предварительынйПросмотрToolStripMenuItem.Size = new System.Drawing.Size(163, 20);
            this.предварительынйПросмотрToolStripMenuItem.Text = "Предварительынй просмотр";
            this.предварительынйПросмотрToolStripMenuItem.Click += new System.EventHandler(this.предварительынйПросмотрToolStripMenuItem_Click);
            // 
            // отменаToolStripMenuItem
            // 
            this.отменаToolStripMenuItem.Name = "отменаToolStripMenuItem";
            this.отменаToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.отменаToolStripMenuItem.Text = "Отмена";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Location = new System.Drawing.Point(12, 27);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(404, 298);
            this.panel3.TabIndex = 13;
            // 
            // pdfDocumentViewer1
            // 
            this.pdfDocumentViewer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.pdfDocumentViewer1.Location = new System.Drawing.Point(526, 27);
            this.pdfDocumentViewer1.MultiPagesThreshold = 60;
            this.pdfDocumentViewer1.Name = "pdfDocumentViewer1";
            this.pdfDocumentViewer1.Size = new System.Drawing.Size(404, 298);
            this.pdfDocumentViewer1.TabIndex = 14;
            this.pdfDocumentViewer1.Text = "pdfDocumentViewer1";
            this.pdfDocumentViewer1.Threshold = 60;
            this.pdfDocumentViewer1.ZoomMode = Spire.PdfViewer.Forms.ZoomMode.Default;
            // 
            // FormPrintDialogForPdf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 335);
            this.Controls.Add(this.pdfDocumentViewer1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormPrintDialogForPdf";
            this.Text = "Печать";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCopies)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFrom)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownColumns)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRows)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxPrintersList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDownCopies;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radioButtonRange;
        private System.Windows.Forms.RadioButton radioButtonAllPage;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox comboBoxSheetsPerList;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelx;
        private System.Windows.Forms.NumericUpDown numericUpDownTo;
        private System.Windows.Forms.NumericUpDown numericUpDownFrom;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.RadioButton radioButtonLandscape;
        private System.Windows.Forms.RadioButton radioButtonPortrait;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numericUpDownColumns;
        private System.Windows.Forms.NumericUpDown numericUpDownRows;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem распечататьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem предварительынйПросмотрToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отменаToolStripMenuItem;
        private System.Windows.Forms.Panel panel3;
        private Spire.PdfViewer.Forms.PdfDocumentViewer pdfDocumentViewer1;
    }
}