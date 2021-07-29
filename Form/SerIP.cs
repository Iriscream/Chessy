using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Chessy1._0
{
    public partial class SerIP : Form
    {
        public SerIP()
        {
            InitializeComponent();
            label2.Text = null;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != null)
            {
                mainForm.cli1.GetSerIP(textBox1.Text);
                this.Close();
            }
            else
            {
                label2.Text = "请输入服务端IP！";
            }
        }

        private void SerIP_Load(object sender, EventArgs e)
        {

        }
    }
}
