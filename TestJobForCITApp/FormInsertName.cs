using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestJobForCITApp
{
    public partial class FormInsertName : Form
    {
        private FormMain.DelegeteGetName _getName;
        public FormInsertName(FormMain.DelegeteGetName getName)
        {
            InitializeComponent();
            _getName = getName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _getName(textBox1.Text);
        }

        
    }
}
