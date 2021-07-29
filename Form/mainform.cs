using System.Windows.Forms;

namespace Chessy1._0
{
    public partial class mainForm : Form
    {
        public static cli_Socket cli1;
        public static bool NetCheck = false;
        public mainForm()
        {
            InitializeComponent();
            cli1 = new cli_Socket();
            if (!NetCheck)
            {
                label1.Text = "Unconnected...";
            }
           
        }
        private bool Connect()
        {
            if (!NetCheck)
            {
                cli1 = new cli_Socket();
                SerIP serip = new SerIP();
                serip.Owner = this;
                serip.ShowDialog();
                if (!cli1.Connect_To_Ser(8800))
                    return false;
                NetCheck = true;
            }
            return true;
        }

        private void button_single_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            singleForm f = new singleForm();
            f.Owner = this;
            f.Show();
        }

        private void button_online_Click(object sender, System.EventArgs e)
        {
            if(NetCheck)
            {
                cli1.rank = cli1.myRank();//登陆前获取最新的排名
                cli1.RankInform();
            }
            this.Hide();
            onlineForm f = new onlineForm();
            f.Owner = this;
            f.Show();
        }

        private void button_signup_Click(object sender, System.EventArgs e)
        {
            if(!Connect())
            {
                MessageBox.Show("Connect Failure!");
                return;
            }    
            sign_upForm f = new sign_upForm();
            f.ShowDialog();
            if (cli1.Idread)
            {
                label1.Text = "Welcome "+cli1.id +" !";
            }
        }

        private void button_login_Click(object sender, System.EventArgs e)
        {
            if (!Connect())
            {
                MessageBox.Show("Connect Failure!");
                return;
            }
            log_inForm f = new log_inForm();
            f.ShowDialog();
            if (cli1.Idread)
            {
                label1.Text = "Welcome "+cli1.id + "!";
            }
        }

        private void button_double_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            doubleForm f = new doubleForm();
            f.Owner = this;
            f.Show();
        }
    }
}
