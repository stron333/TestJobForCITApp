using System;
using System.Windows.Forms;

namespace TestJobForCITApp
{
    public partial class FormInsertName : Form
    {
        private string _name;
        public FormInsertName(string formText)
        {
            InitializeComponent();
            this.Text = formText;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
