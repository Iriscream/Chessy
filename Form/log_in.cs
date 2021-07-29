using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Chessy1._0
{
    public partial class log_inForm : Form
    {
        public log_inForm()
        {
            InitializeComponent();
            label1.Text = null;
            if (mainForm.cli1.Idread)
            {
                textBox_name.Text = mainForm.cli1.id;
            }
            textBox_password.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string msg = mainForm.cli1.login(textBox_name.Text, textBox_password.Text);
            //三种返回类型判断
            if (msg == "ID")
            {
                label1.Text = "该用户不存在";
                textBox_name.Clear();
                textBox_password.Clear();
                //清空两行
            }
            if (msg == "PASSWORD")
            {
                label1.Text = "密码错误";
                textBox_password.Clear();
                //只清空密码行
            }
            if (msg == "TRUE")
            {
                //MessageBox.Show("登陆成功");
                this.Close();
            }
        }

        private void log_inForm_Load(object sender, EventArgs e)
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
