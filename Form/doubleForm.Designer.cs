
namespace Chessy1._0
{
    partial class doubleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(doubleForm));
            this.boardImage = new System.Windows.Forms.PictureBox();
            this.rank = new System.Windows.Forms.Button();
            this.withdraw = new System.Windows.Forms.Button();
            this.TomainForm = new System.Windows.Forms.Button();
            this.help = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.boardImage)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // boardImage
            // 
            this.boardImage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("boardImage.BackgroundImage")));
            this.boardImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.boardImage.Location = new System.Drawing.Point(348, 19);
            this.boardImage.Margin = new System.Windows.Forms.Padding(0);
            this.boardImage.Name = "boardImage";
            this.boardImage.Size = new System.Drawing.Size(721, 713);
            this.boardImage.TabIndex = 1;
            this.boardImage.TabStop = false;
            this.boardImage.Click += new System.EventHandler(this.boardImage_Click);
            this.boardImage.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Play);
            // 
            // rank
            // 
            this.rank.BackColor = System.Drawing.Color.SandyBrown;
            this.rank.BackgroundImage = global::Chessy1._0.Properties.Resources.排行__1_;
            this.rank.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.rank.Location = new System.Drawing.Point(21, 482);
            this.rank.Margin = new System.Windows.Forms.Padding(2);
            this.rank.Name = "rank";
            this.rank.Size = new System.Drawing.Size(104, 107);
            this.rank.TabIndex = 11;
            this.rank.UseVisualStyleBackColor = false;
            this.rank.Click += new System.EventHandler(this.rank_Click);
            // 
            // withdraw
            // 
            this.withdraw.BackColor = System.Drawing.Color.SandyBrown;
            this.withdraw.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("withdraw.BackgroundImage")));
            this.withdraw.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.withdraw.Location = new System.Drawing.Point(230, 482);
            this.withdraw.Margin = new System.Windows.Forms.Padding(2);
            this.withdraw.Name = "withdraw";
            this.withdraw.Size = new System.Drawing.Size(104, 107);
            this.withdraw.TabIndex = 12;
            this.withdraw.UseVisualStyleBackColor = false;
            this.withdraw.Click += new System.EventHandler(this.b_reverse_Click);
            // 
            // TomainForm
            // 
            this.TomainForm.BackColor = System.Drawing.Color.SandyBrown;
            this.TomainForm.BackgroundImage = global::Chessy1._0.Properties.Resources.退出__1_;
            this.TomainForm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.TomainForm.Location = new System.Drawing.Point(21, 625);
            this.TomainForm.Margin = new System.Windows.Forms.Padding(2);
            this.TomainForm.Name = "TomainForm";
            this.TomainForm.Size = new System.Drawing.Size(104, 107);
            this.TomainForm.TabIndex = 13;
            this.TomainForm.UseVisualStyleBackColor = false;
            this.TomainForm.Click += new System.EventHandler(this.b_out_Click);
            // 
            // help
            // 
            this.help.BackColor = System.Drawing.Color.SandyBrown;
            this.help.BackgroundImage = global::Chessy1._0.Properties.Resources.帮_助;
            this.help.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.help.Location = new System.Drawing.Point(230, 625);
            this.help.Margin = new System.Windows.Forms.Padding(2);
            this.help.Name = "help";
            this.help.Size = new System.Drawing.Size(104, 107);
            this.help.TabIndex = 14;
            this.help.UseVisualStyleBackColor = false;
            this.help.Click += new System.EventHandler(this.help_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Bisque;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(76, 207);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(189, 124);
            this.panel2.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(105, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "label2";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(17, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "Turns:";
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::Chessy1._0.Properties.Resources.doublelogo;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(21, 21);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(313, 143);
            this.panel1.TabIndex = 16;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // doubleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Chessy1._0.Properties.Resources.背景色;
            this.ClientSize = new System.Drawing.Size(1078, 751);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.help);
            this.Controls.Add(this.TomainForm);
            this.Controls.Add(this.withdraw);
            this.Controls.Add(this.rank);
            this.Controls.Add(this.boardImage);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "doubleForm";
            this.Text = "Double Players";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.doubleForm_FormClosed);
            this.Load += new System.EventHandler(this.doubleForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.boardImage)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox boardImage;
        private System.Windows.Forms.Button rank;
        private System.Windows.Forms.Button withdraw;
        private System.Windows.Forms.Button TomainForm;
        private System.Windows.Forms.Button help;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
    }
}