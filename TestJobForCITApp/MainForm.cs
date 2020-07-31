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
        private BindingList<DataTable> _listDataSets;
        public delegate string DelegeteGetName(string s);
        public FormMain()
        {
            InitializeComponent();
            _listDataSets = new BindingList<DataTable>();
            listBoxTables.DataSource = _listDataSets;

            Application.EnableVisualStyles();


        }

        private void buttonAddTable_Click(object sender, EventArgs e)
        {

            DataTable dataTable = new DataTable();
            _listDataSets.Add(dataTable);
        }

        

        private void listBoxTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _listDataSets[listBoxTables.SelectedIndex];
        }

        private void новыйСтолбецToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _listDataSets[listBoxTables.SelectedIndex].Columns.Add("New");
            dataGridView1.Refresh();
        }

        private string InsertName()
        {
            this.Enabled = false;
            
            FormInsertName formInsertName = new FormInsertName(GetName);
            string name = "";
            formInsertName.FormClosing += delegate
            {
                name = formInsertName.textBox1.Text; this.Enabled = true;
            };
            return name;
        }

        private string GetName(string name)
        {
            return name;
        }
    }
}
