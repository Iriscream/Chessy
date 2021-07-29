using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Chessy1._0
{
    public partial class sign_upForm : Form
    {
        public sign_upForm()
        {
            InitializeComponent();
            label1.Text = null;
            textBox_password.PasswordChar = '*';
        }

        private void sign_up_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string msg = mainForm.cli1.signin(textBox_name.Text, textBox_password.Text);
            if (msg == "ID")
            {
                label1.Text = "该用户名已存在";
                textBox_name.Clear();
                textBox_password.Clear();
            }
            if (msg == "PASSWORD")
            {
                label1.Text = "服务器繁忙";
                this.Close();
            }
            if (msg == "TRUE")
            {
                this.Close();
            }
        }

        private void sign_upForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox_password.PasswordChar = '\0';
            }
            else
            {
                textBox_password.PasswordChar = '*';
            }
        }
    }
}
