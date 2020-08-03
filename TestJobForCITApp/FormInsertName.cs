using System;
using System.Drawing;
using System.Windows.Forms;

namespace TestJobForCITApp
{
    public partial class FormInsertName : Form
    {
        private string _name;
        public FormInsertName(string formText)
        {
            InitializeComponent();
            this.Location = new Point(Cursor.Position.X + 10, Cursor.Position.Y);
            this.Size = new Size(311, 81);
            this.Text = formText;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
