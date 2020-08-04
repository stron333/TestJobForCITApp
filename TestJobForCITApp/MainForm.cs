using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestJobForCITApp
{
    public partial class FormMain : Form
    {
        private BindingList<DataTable> _listDataTables;
        public FormMain()
        {
            InitializeComponent();
            _listDataTables = new BindingList<DataTable>();
            listBoxTables.DataSource = _listDataTables;
            listBoxTables.DisplayMember = "TableName";
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
            _listDataTables[listBoxTables.SelectedIndex].
                Columns.Add(
                    InsertName("Введите имя столбца"
                    ));
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
            var SelectedCellIndex = dataGridView1.SelectedCells[0].ColumnIndex;
            _listDataTables[listBoxTables.SelectedIndex].Columns[SelectedCellIndex].ColumnName =
                InsertName("Введите имя столбца");
        }
    }

    
}
