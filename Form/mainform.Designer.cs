
namespace Chessy1._0
{
    partial class mainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.button_single = new System.Windows.Forms.Button();
            this.button_online = new System.Windows.Forms.Button();
            this.button_signup = new System.Windows.Forms.Button();
            this.button_login = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button_double = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackgroundImage = global::Chessy1._0.Properties.Resources.logo5;
            this.flowLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(17, 12);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(563, 323);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // button_single
            // 
            this.button_single.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_single.BackgroundImage")));
            this.button_single.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_single.Location = new System.Drawing.Point(127, 341);
            this.button_single.Name = "button_single";
            this.button_single.Size = new System.Drawing.Size(332, 119);
            this.button_single.TabIndex = 2;
            this.button_single.UseVisualStyleBackColor = true;
            this.button_single.Click += new System.EventHandler(this.button_single_Click);
            // 
            // button_online
            // 
            this.button_online.BackgroundImage = global::Chessy1._0.Properties.Resources.button3图片;
            this.button_online.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_online.Location = new System.Drawing.Point(127, 662);
            this.button_online.Name = "button_online";
            this.button_online.Size = new System.Drawing.Size(332, 119);
            this.button_online.TabIndex = 3;
            this.button_online.UseVisualStyleBackColor = true;
            this.button_online.Click += new System.EventHandler(this.button_online_Click);
            // 
            // button_signup
            // 
            this.button_signup.BackColor = System.Drawing.Color.SandyBrown;
            this.button_signup.ForeColor = System.Drawing.SystemColors.Window;
            this.button_signup.Location = new System.Drawing.Point(17, 813);
            this.button_signup.Name = "button_signup";
            this.button_signup.Size = new System.Drawing.Size(133, 41);
            this.button_signup.TabIndex = 4;
            this.button_signup.Text = "Sign up";
            this.button_signup.UseVisualStyleBackColor = false;
            this.button_signup.Click += new System.EventHandler(this.button_signup_Click);
            // 
            // button_login
            // 
            this.button_login.BackColor = System.Drawing.Color.SandyBrown;
            this.button_login.ForeColor = System.Drawing.SystemColors.Window;
            this.button_login.Location = new System.Drawing.Point(437, 813);
            this.button_login.Name = "button_login";
            this.button_login.Size = new System.Drawing.Size(133, 41);
            this.button_login.TabIndex = 5;
            this.button_login.Text = "Log in";
            this.button_login.UseVisualStyleBackColor = false;
            this.button_login.Click += new System.EventHandler(this.button_login_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(224, 826);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 28);
            this.label1.TabIndex = 6;
            this.label1.Text = "label1";
            // 
            // button_double
            // 
            this.button_double.BackgroundImage = global::Chessy1._0.Properties.Resources.button2图片;
            this.button_double.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_double.Location = new System.Drawing.Point(127, 502);
            this.button_double.Name = "button_double";
            this.button_double.Size = new System.Drawing.Size(332, 119);
            this.button_double.TabIndex = 7;
            this.button_double.UseVisualStyleBackColor = true;
            this.button_double.Click += new System.EventHandler(this.button_double_Click);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.BackgroundImage = global::Chessy1._0.Properties.Resources.背景色;
            this.ClientSize = new System.Drawing.Size(592, 875);
            this.Controls.Add(this.button_double);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_login);
            this.Controls.Add(this.button_signup);
            this.Controls.Add(this.button_online);
            this.Controls.Add(this.button_single);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "mainForm";
            this.Text = "Chessy";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button button_single;
        private System.Windows.Forms.Button button_online;
        private System.Windows.Forms.Button button_signup;
        private System.Windows.Forms.Button button_login;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_double;
    }
}

