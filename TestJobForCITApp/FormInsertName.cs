using System;
using System.Drawing;
using System.Windows.Forms;

namespace TestJobForCITApp
{
    public partial class FormInsertName : Form
    {
        public FormInsertName(string formText)
        {
            InitializeComponent();
            this.Location = new Point(Cursor.Position.X + 10, Cursor.Position.Y);
            this.Size = new Size(311, 81);
            this.Text = formText;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        private void CloseForm()
        {
            if (textBox1.Text == "")
                MessageBox.Show("Необходимо ввести имя",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            else
                this.Close();

        }


        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CloseForm();
            }
        }
    }
}
