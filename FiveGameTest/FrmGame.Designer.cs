namespace FiveGameTest
{
    partial class FrmGame
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lblWPlayer = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblBPlayer = new System.Windows.Forms.Label();
            this.picStart = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picStart)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblWPlayer
            // 
            this.lblWPlayer.AutoSize = true;
            this.lblWPlayer.BackColor = System.Drawing.Color.Transparent;
            this.lblWPlayer.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblWPlayer.ForeColor = System.Drawing.Color.Black;
            this.lblWPlayer.Location = new System.Drawing.Point(52, 110);
            this.lblWPlayer.Name = "lblWPlayer";
            this.lblWPlayer.Size = new System.Drawing.Size(56, 17);
            this.lblWPlayer.TabIndex = 4;
            this.lblWPlayer.Text = "白方昵称";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Sienna;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.picStart);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(170, 589);
            this.panel1.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.BackgroundImage = global::FiveGameTest.Properties.Resources.heifang;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Controls.Add(this.lblBPlayer);
            this.panel3.Location = new System.Drawing.Point(12, 73);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(148, 245);
            this.panel3.TabIndex = 9;
            // 
            // lblBPlayer
            // 
            this.lblBPlayer.AutoSize = true;
            this.lblBPlayer.BackColor = System.Drawing.Color.Transparent;
            this.lblBPlayer.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBPlayer.ForeColor = System.Drawing.Color.Black;
            this.lblBPlayer.Location = new System.Drawing.Point(39, 110);
            this.lblBPlayer.Name = "lblBPlayer";
            this.lblBPlayer.Size = new System.Drawing.Size(56, 17);
            this.lblBPlayer.TabIndex = 4;
            this.lblBPlayer.Text = "黑方昵称";
            // 
            // picStart
            // 
            this.picStart.Image = global::FiveGameTest.Properties.Resources.start;
            this.picStart.Location = new System.Drawing.Point(77, 345);
            this.picStart.Name = "picStart";
            this.picStart.Size = new System.Drawing.Size(83, 26);
            this.picStart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picStart.TabIndex = 8;
            this.picStart.TabStop = false;
            this.picStart.Click += new System.EventHandler(this.picStart_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Sienna;
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(773, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(170, 589);
            this.panel2.TabIndex = 6;
            // 
            // panel4
            // 
            this.panel4.BackgroundImage = global::FiveGameTest.Properties.Resources.baifang;
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel4.Controls.Add(this.lblWPlayer);
            this.panel4.Location = new System.Drawing.Point(10, 73);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(148, 245);
            this.panel4.TabIndex = 10;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Location = new System.Drawing.Point(230, 50);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(480, 480);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            // 
            // FrmGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SaddleBrown;
            this.ClientSize = new System.Drawing.Size(943, 589);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmGame";
            this.Text = "五子棋";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmGame_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResizeBegin += new System.EventHandler(this.Form1_ResizeBegin);
            this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picStart)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblWPlayer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblBPlayer;
        private System.Windows.Forms.PictureBox picStart;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

