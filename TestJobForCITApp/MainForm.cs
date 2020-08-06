using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

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

            classForPrinting.ListFields.Field1 = textBoxField1.Text;
            classForPrinting.ListFields.Field2 = textBoxField2.Text;
            classForPrinting.ListFields.Field3 = textBoxField3.Text;
            classForPrinting.ListFields.Field4 = textBoxField4.Text;
            classForPrinting.ListFields.Field5 = textBoxField5.Text;
            classForPrinting.ListFields.Field6 = textBoxField6.Text;
            classForPrinting.ListFields.Field7 = textBoxField7.Text;
            classForPrinting.ListFields.Field8 = textBoxField8.Text;
            classForPrinting.ListFields.Field9 = textBoxField9.Text;
            classForPrinting.ListFields.Field10 = textBoxField10.Text;
            classForPrinting.ListFiles = _listFiles.ToList();
            classForPrinting.ListTables = _listDataTables.ToList();

            XmlSerializer formatter = new XmlSerializer(typeof(ClassForPrinting));
            if (File.Exists("classForPrinting.xml")) 
                File.Delete("classForPrinting.xml");

            using (FileStream fs = new FileStream("classForPrinting.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, classForPrinting);
            }
            
            webBrowser1.Url = new Uri(@"C:\Users\Alex\source\repos\TestJobForCITApp\TestJobForCITApp\bin\Debug\classForPrinting.xml");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<TableForXML> tablesForXml = new List<TableForXML>();
            foreach (DataTable listDataTable in _listDataTables)
            {
                tablesForXml.Add(new TableForXML().ConvertDataTAble(listDataTable));
            }

            XmlSerializer formatter = new XmlSerializer(typeof(List<TableForXML>));
            if (File.Exists("table.xml"))
                File.Delete("table.xml");

            using (FileStream fs = new FileStream("table.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, tablesForXml);
            }
            File.AppendAllText("table.xml", Environment.NewLine+
                @"<?xml-stylesheet type=""text/css"" href=""css.css""?>");

            //webControl1.Source = new Uri(@"C:\Users\Alex\source\repos\TestJobForCITApp\TestJobForCITApp\bin\Debug\table.xml");
            //webControl1.Source = new Uri("https://www.cyberforum.ru/windows-forms/thread1538487.html");
            //webControl1.Source = new Uri(@"C:\Users\Alex\source\repos\TestJobForCITApp\TestJobForCITApp\bin\Debug\10_3.xml");

        }
    }

    
}
