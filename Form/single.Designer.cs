
namespace Chessy1._0
{
    partial class singleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(singleForm));
            this.boardImage = new System.Windows.Forms.PictureBox();
            this.help = new System.Windows.Forms.Button();
            this.TomainForm = new System.Windows.Forms.Button();
            this.withdraw = new System.Windows.Forms.Button();
            this.rank = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.boardImage)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // boardImage
            // 
            this.boardImage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("boardImage.BackgroundImage")));
            this.boardImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.boardImage.Location = new System.Drawing.Point(521, 29);
            this.boardImage.Margin = new System.Windows.Forms.Padding(0);
            this.boardImage.Name = "boardImage";
            this.boardImage.Size = new System.Drawing.Size(1036, 991);
            this.boardImage.TabIndex = 1;
            this.boardImage.TabStop = false;
            this.boardImage.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Play);
            // 
            // help
            // 
            this.help.BackColor = System.Drawing.Color.SandyBrown;
            this.help.BackgroundImage = global::Chessy1._0.Properties.Resources.帮_助;
            this.help.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.help.Location = new System.Drawing.Point(332, 869);
            this.help.Name = "help";
            this.help.Size = new System.Drawing.Size(150, 150);
            this.help.TabIndex = 13;
            this.help.UseVisualStyleBackColor = false;
            this.help.Click += new System.EventHandler(this.help_Click);
            // 
            // TomainForm
            // 
            this.TomainForm.BackColor = System.Drawing.Color.SandyBrown;
            this.TomainForm.BackgroundImage = global::Chessy1._0.Properties.Resources.退出__1_;
            this.TomainForm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.TomainForm.Location = new System.Drawing.Point(27, 869);
            this.TomainForm.Name = "TomainForm";
            this.TomainForm.Size = new System.Drawing.Size(150, 150);
            this.TomainForm.TabIndex = 12;
            this.TomainForm.UseVisualStyleBackColor = false;
            this.TomainForm.Click += new System.EventHandler(this.mainForm_Click);
            // 
            // withdraw
            // 
            this.withdraw.BackColor = System.Drawing.Color.SandyBrown;
            this.withdraw.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("withdraw.BackgroundImage")));
            this.withdraw.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.withdraw.Location = new System.Drawing.Point(332, 652);
            this.withdraw.Name = "withdraw";
            this.withdraw.Size = new System.Drawing.Size(150, 150);
            this.withdraw.TabIndex = 11;
            this.withdraw.UseVisualStyleBackColor = false;
            this.withdraw.Click += new System.EventHandler(this.withdraw_Click);
            // 
            // rank
            // 
            this.rank.BackColor = System.Drawing.Color.SandyBrown;
            this.rank.BackgroundImage = global::Chessy1._0.Properties.Resources.排行__1_;
            this.rank.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.rank.Location = new System.Drawing.Point(27, 652);
            this.rank.Name = "rank";
            this.rank.Size = new System.Drawing.Size(150, 150);
            this.rank.TabIndex = 10;
            this.rank.UseVisualStyleBackColor = false;
            this.rank.Click += new System.EventHandler(this.rank_Click);
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
            this.panel3.Location = new System.Drawing.Point(27, 452);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(455, 160);
            this.panel3.TabIndex = 7;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(127, 120);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(24, 28);
            this.label12.TabIndex = 6;
            this.label12.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(127, 69);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(76, 28);
            this.label11.TabIndex = 5;
            this.label11.Text = "1000+";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(127, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(33, 28);
            this.label10.TabIndex = 4;
            this.label10.Text = "AI";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("隶书", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(9, 118);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 28);
            this.label9.TabIndex = 3;
            this.label9.Text = "RANK:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("隶书", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(9, 69);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(102, 28);
            this.label8.TabIndex = 2;
            this.label8.Text = "SCORE:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("隶书", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(9, 22);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 28);
            this.label7.TabIndex = 1;
            this.label7.Text = "ID:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(30, 262);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(452, 160);
            this.panel2.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(124, 119);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 28);
            this.label6.TabIndex = 5;
            this.label6.Text = "label6";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(124, 69);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 28);
            this.label5.TabIndex = 4;
            this.label5.Text = "label5";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(124, 18);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 28);
            this.label4.TabIndex = 3;
            this.label4.Text = "label4";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("隶书", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(6, 119);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 28);
            this.label3.TabIndex = 2;
            this.label3.Text = "RANK:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("隶书", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(6, 69);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 28);
            this.label2.TabIndex = 1;
            this.label2.Text = "SCORE:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("隶书", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(6, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID:";
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::Chessy1._0.Properties.Resources.single;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(30, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(452, 200);
            this.panel1.TabIndex = 8;
            // 
            // singleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Chessy1._0.Properties.Resources.背景色;
            this.ClientSize = new System.Drawing.Size(1592, 1056);
            this.Controls.Add(this.help);
            this.Controls.Add(this.TomainForm);
            this.Controls.Add(this.withdraw);
            this.Controls.Add(this.rank);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.boardImage);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "singleForm";
            this.Text = "Single Player";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.singleForm_FormClosed);
            this.Load += new System.EventHandler(this.singleForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.boardImage)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox boardImage;
        private System.Windows.Forms.Button help;
        private System.Windows.Forms.Button TomainForm;
        private System.Windows.Forms.Button withdraw;
        private System.Windows.Forms.Button rank;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
    }
}