using System;
using System.IO;
using System.Windows.Forms;

namespace TestJobForCITApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.ShowDialog();
            StreamReader streamReader = new StreamReader(dialog.FileName); //test.css is Stylesheet file
            string text = streamReader.ReadToEnd();
            


        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
