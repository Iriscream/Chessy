using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Chessy1._0
{
    public partial class rankForm : Form
    {
        public rankForm()
        {
            InitializeComponent();
            label1.Text = null;
            label2.Text = null;
            label3.Text = null;
            label4.Text = null;
            label5.Text = null;
            label6.Text = null;
            label7.Text = null;
            label8.Text = null;
            label9.Text = null;
            label10.Text = null;
            if (mainForm.NetCheck&&!onlineForm.live)
            {
                mainForm.cli1.RankInform();
            }
            ShowInform();
        }
        public void ShowInform()
        {
            if(mainForm.cli1.WorldRank.ContainsKey(1))
                label1.Text = mainForm.cli1.WorldRank[1].id + " " + mainForm.cli1.WorldRank[1].score;
            else
                return;
            if (mainForm.cli1.WorldRank.ContainsKey(2))
                label2.Text = mainForm.cli1.WorldRank[2].id + " " + mainForm.cli1.WorldRank[2].score;
            else
                return;
            if (mainForm.cli1.WorldRank.ContainsKey(3))
                label3.Text = mainForm.cli1.WorldRank[3].id + " " + mainForm.cli1.WorldRank[3].score;
            else
                return;
            if (mainForm.cli1.WorldRank.ContainsKey(4))
                label4.Text = mainForm.cli1.WorldRank[4].id + " " + mainForm.cli1.WorldRank[4].score;
            else
                return;
            if (mainForm.cli1.WorldRank.ContainsKey(5))
                label5.Text = mainForm.cli1.WorldRank[5].id + " " + mainForm.cli1.WorldRank[5].score;
            else
                return;
            if (mainForm.cli1.WorldRank.ContainsKey(6))
                label6.Text = mainForm.cli1.WorldRank[6].id + " " + mainForm.cli1.WorldRank[6].score;
            else
                return;
            if (mainForm.cli1.WorldRank.ContainsKey(7))
                label7.Text = mainForm.cli1.WorldRank[7].id + " " + mainForm.cli1.WorldRank[7].score;
            else
                return;
            if (mainForm.cli1.WorldRank.ContainsKey(8))
                label8.Text = mainForm.cli1.WorldRank[8].id + " " + mainForm.cli1.WorldRank[8].score;
            else
                return;
            if (mainForm.cli1.WorldRank.ContainsKey(9))
                label9.Text = mainForm.cli1.WorldRank[9].id + " " + mainForm.cli1.WorldRank[9].score;
            else
                return;
            if (mainForm.cli1.WorldRank.ContainsKey(10))
                label10.Text = mainForm.cli1.WorldRank[10].id + " " + mainForm.cli1.WorldRank[10].score;
            else
                return;
        }

        private void rankForm_Load(object sender, EventArgs e)
        {

        }
    }
}
