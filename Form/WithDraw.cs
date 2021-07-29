using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Chessy1._0
{
    public partial class WithDraw : Form
    {
        public bool Agree=false;
        public WithDraw()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Agree = true;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Agree = false;
            this.Close();
        }
    }
}
