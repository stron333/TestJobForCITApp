using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using Awesomium.Core;

namespace TestJobForCITApp
{
    public partial class FormMain : Form
    {
        private BindingList<DataTable> _listDataTables;
        private BindingList<string> _listFiles;

        public FormMain()
        {
            InitializeComponent();
            _listDataTables = new BindingList<DataTable>();
            listBoxTables.DataSource = _listDataTables;
            listBoxTables.DisplayMember = "TableName";

            _listFiles = new BindingList<string>();
            listBoxFiles.DataSource = _listFiles;
        }

        private void buttonAddTable_Click(object sender, EventArgs e)
        {
            DataTable newDataTable = new DataTable();
            newDataTable.TableName = InsertName(
                "Введите имя таблицы");
            _listDataTables.Add(newDataTable);
            listBoxTables_SelectedIndexChanged(sender, e);
            listBoxTables.SelectedIndex = listBoxTables.Items.Count - 1;
        }

        

        private void listBoxTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            if (_listDataTables.Count != 0)
                dataGridView1.DataSource = _listDataTables[listBoxTables.SelectedIndex];
            if (listBoxTables.SelectedIndex >= 0)
            {
                buttonRenameTable.Enabled = true;
                buttonDeleteTable.Enabled = true;
                menuStripForTable.Enabled = true;
            }
            else
            {
                buttonRenameTable.Enabled = false;
                buttonDeleteTable.Enabled = false;
                menuStripForTable.Enabled = false;

            }
        }

        private void новыйСтолбецToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                _listDataTables[listBoxTables.SelectedIndex].
                    Columns.Add(
                        InsertName("Введите имя столбца"
                        ));
            }
            catch (DuplicateNameException exception)
            {
                MessageBox.Show("Столбец с таким именем уже существует",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            
        }

        private string InsertName(string TextOnForm)
        {
            string name = "";
            FormInsertName formInsertName = new FormInsertName(TextOnForm);
            formInsertName.Closing += delegate { name = formInsertName.textBox1.Text; };
            formInsertName.ShowDialog();
            return name;
        }

        private void buttonDeleteTable_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить выбранную таблицу?", "Внимание", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                _listDataTables.Remove(_listDataTables[listBoxTables.SelectedIndex]);
                listBoxTables_SelectedIndexChanged(sender, e);
            }
        }

        private void buttonRenameTable_Click(object sender, EventArgs e)
        {
            _listDataTables[listBoxTables.SelectedIndex].
                TableName = InsertName("Введите имя таблицы");

            DataTable newDataTable = new DataTable();
            _listDataTables.Add(newDataTable);
            _listDataTables.Remove(newDataTable);
        }

        private void переименоватьСтолбецToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int SelectedCellIndex = dataGridView1.SelectedCells[0].ColumnIndex;
                _listDataTables[listBoxTables.SelectedIndex].Columns[SelectedCellIndex].ColumnName =
                    InsertName("Введите имя столбца");
            }
            catch (ArgumentException exception)
            {
                MessageBox.Show("Неверное имя для столбца",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (DuplicateNameException exception)
            {
                MessageBox.Show("Столбец с таким именем уже существует", 
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }


        }

        private void dataGridView1_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            переименоватьСтолбецToolStripMenuItem.Enabled = false;
            удалитьToolStripMenuItem.Enabled = false;
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            переименоватьСтолбецToolStripMenuItem.Enabled = true;
            удалитьToolStripMenuItem.Enabled = true;
        }

        private void удалитьстолбецToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить выбранный столбец?", "Внимание",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                int SelectedCellIndex = dataGridView1.SelectedCells[0].ColumnIndex;
                var SelectedCell = _listDataTables[listBoxTables.SelectedIndex].Columns[SelectedCellIndex];
                _listDataTables[listBoxTables.SelectedIndex].Columns.Remove(SelectedCell);
            }
        }

        private void удалитьстрокуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить выбранную строку?", "Внимание",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                int SelectedRowIndex = dataGridView1.SelectedCells[0].RowIndex;
                if (SelectedRowIndex < _listDataTables[listBoxTables.SelectedIndex].Rows.Count)
                {
                    var SelectedRow = _listDataTables[listBoxTables.SelectedIndex].Rows[SelectedRowIndex];
                    _listDataTables[listBoxTables.SelectedIndex].Rows.Remove(SelectedRow);
                }
            }
        }

        private void buttonAddFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog1.FileName;
            _listFiles.Add(filename);
            listBoxFiles.SelectedIndex = listBoxFiles.Items.Count - 1;
            listBoxFiles_SelectedIndexChanged(sender, e);
        }

        private void buttonDeleteFile_Click(object sender, EventArgs e)
        {
            _listFiles.Remove(_listFiles[listBoxFiles.SelectedIndex]);
        }

        private void listBoxFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_listFiles.Count == 0)
                buttonDeleteFile.Enabled = false;
            else
                buttonDeleteFile.Enabled = true;
        }

        private void сформироватьXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClassForPrinting classForPrinting = new ClassForPrinting();
            string pathToXml = Directory.GetCurrentDirectory() + "/classForPrinting.xml";
            classForPrinting.ListFields = FillListField();
            
            foreach (DataTable listDataTable in _listDataTables)
            {
                classForPrinting.ListTables.Add(
                    new TableForXML().ConvertDataTAble(listDataTable));
            }

            foreach (string filePath in _listFiles)
            {
                classForPrinting.ListFiles.Add(
                    new FileToXml().ConvertFile(filePath));
            }

            XmlSerializer formatter = new XmlSerializer(typeof(ClassForPrinting));
            if (File.Exists(pathToXml)) 
                File.Delete(pathToXml);

            using (FileStream fs = new FileStream(pathToXml, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, classForPrinting);
            }
                
            File.AppendAllText(pathToXml, 
                Environment.NewLine + @"<?xml-stylesheet type=""text/css"" href=""style.css""?>");
            string text = File.ReadAllText(pathToXml);
            text = text.Replace("&lt;", "<");
            text = text.Replace("&gt;", ">"); 
            File.WriteAllText(pathToXml, text);


            this.Enabled = false;
            FormBrowser formBrowser = new FormBrowser(new Uri(pathToXml));
            formBrowser.Closing += delegate { this.Enabled = true; };
            formBrowser.Show();
        }


        private ListFields FillListField()
        {
            ListFields newList = new ListFields();
            newList.Field.Add(
                new Field() { Name = labelField1.Text, Text = textBoxField1.Text });
            newList.Field.Add(
                new Field() { Name = labelField2.Text, Text = textBoxField2.Text });
            newList.Field.Add(
                new Field() { Name = labelField3.Text, Text = textBoxField3.Text });
            newList.Field.Add(
                new Field() { Name = labelField4.Text, Text = textBoxField4.Text });
            newList.Field.Add(
                new Field() { Name = labelField5.Text, Text = textBoxField5.Text });
            newList.Field.Add(
                new Field() { Name = labelField6.Text, Text = textBoxField6.Text });
            newList.Field.Add(
                new Field() { Name = labelField7.Text, Text = textBoxField7.Text });
            newList.Field.Add(
                new Field() { Name = labelField8.Text, Text = textBoxField8.Text });
            newList.Field.Add(
                new Field() { Name = labelField9.Text, Text = textBoxField9.Text });
            newList.Field.Add(
                new Field() { Name = labelField10.Text, Text = textBoxField10.Text });
            return newList;
        }



        private void заполнитьТестовымиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBoxField1.Text = "Текст в поле 1";
            textBoxField2.Text = "Текст в поле 2";
            textBoxField3.Text = "Текст в поле 3";
            textBoxField4.Text = "Текст в поле 4";
            textBoxField5.Text = "Текст в поле 5";
            textBoxField6.Text = "Текст в поле 6";
            textBoxField7.Text = "Текст в поле 7";
            textBoxField8.Text = "Текст в поле 8";
            textBoxField9.Text = "Текст в поле 9";
            textBoxField10.Text = "Текст в поле 10";
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }

    
}
