
namespace Chessy1._0
{
    partial class onlineForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(onlineForm));
            this.boardImage = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.rank = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.help = new System.Windows.Forms.Button();
            this.TomainForm = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.boardImage)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // boardImage
            // 
            this.boardImage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("boardImage.BackgroundImage")));
            this.boardImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.boardImage.Location = new System.Drawing.Point(408, 21);
            this.boardImage.Margin = new System.Windows.Forms.Padding(0);
            this.boardImage.Name = "boardImage";
            this.boardImage.Size = new System.Drawing.Size(721, 713);
            this.boardImage.TabIndex = 0;
            this.boardImage.TabStop = false;
            this.boardImage.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Play);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::Chessy1._0.Properties.Resources.online_logo;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(21, 21);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(313, 143);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(21, 186);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(313, 114);
            this.panel2.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(89, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "label6";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(89, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "label5";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(89, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "label4";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("隶书", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(8, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "RANK:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("隶书", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(8, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "SCORE:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("隶书", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(9, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Location = new System.Drawing.Point(21, 321);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(313, 114);
            this.panel3.TabIndex = 0;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(89, 79);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(62, 20);
            this.label12.TabIndex = 5;
            this.label12.Text = "label12";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(89, 49);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 20);
            this.label11.TabIndex = 4;
            this.label11.Text = "label11";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(89, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 20);
            this.label10.TabIndex = 3;
            this.label10.Text = "label10";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("隶书", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(9, 79);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 20);
            this.label9.TabIndex = 2;
            this.label9.Text = "RANK:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("隶书", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(8, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 20);
            this.label8.TabIndex = 1;
            this.label8.Text = "SCORE:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("隶书", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(8, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 20);
            this.label7.TabIndex = 0;
            this.label7.Text = "Name:";
            // 
            // rank
            // 
            this.rank.BackColor = System.Drawing.Color.SandyBrown;
            this.rank.BackgroundImage = global::Chessy1._0.Properties.Resources.排行__1_;
            this.rank.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.rank.Location = new System.Drawing.Point(21, 479);
            this.rank.Margin = new System.Windows.Forms.Padding(2);
            this.rank.Name = "rank";
            this.rank.Size = new System.Drawing.Size(104, 107);
            this.rank.TabIndex = 12;
            this.rank.UseVisualStyleBackColor = false;
            this.rank.Click += new System.EventHandler(this.rank_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.SandyBrown;
            this.button3.BackgroundImage = global::Chessy1._0.Properties.Resources.旗子;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.Location = new System.Drawing.Point(230, 479);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(104, 107);
            this.button3.TabIndex = 5;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.Out_Click);
            // 
            // help
            // 
            this.help.BackColor = System.Drawing.Color.SandyBrown;
            this.help.BackgroundImage = global::Chessy1._0.Properties.Resources.帮_助;
            this.help.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.help.Location = new System.Drawing.Point(230, 616);
            this.help.Margin = new System.Windows.Forms.Padding(2);
            this.help.Name = "help";
            this.help.Size = new System.Drawing.Size(104, 107);
            this.help.TabIndex = 15;
            this.help.UseVisualStyleBackColor = false;
            this.help.Click += new System.EventHandler(this.button4_Click);
            // 
            // TomainForm
            // 
            this.TomainForm.BackColor = System.Drawing.Color.SandyBrown;
            this.TomainForm.BackgroundImage = global::Chessy1._0.Properties.Resources.退出__1_;
            this.TomainForm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.TomainForm.Location = new System.Drawing.Point(21, 616);
            this.TomainForm.Margin = new System.Windows.Forms.Padding(2);
            this.TomainForm.Name = "TomainForm";
            this.TomainForm.Size = new System.Drawing.Size(104, 107);
            this.TomainForm.TabIndex = 16;
            this.TomainForm.UseVisualStyleBackColor = false;
            this.TomainForm.Click += new System.EventHandler(this.Out_Click);
            // 
            // onlineForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Chessy1._0.Properties.Resources.背景色;
            this.ClientSize = new System.Drawing.Size(1143, 750);
            this.Controls.Add(this.TomainForm);
            this.Controls.Add(this.help);
            this.Controls.Add(this.rank);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.boardImage);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "onlineForm";
            this.Text = "Play Online";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.onlineForm_FormClosed);
            this.Shown += new System.EventHandler(this.onlineForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.boardImage)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox boardImage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button rank;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button help;
        private System.Windows.Forms.Button TomainForm;
    }
}