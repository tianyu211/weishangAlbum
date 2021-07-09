namespace Demo
{
    partial class Form1
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button2 = new System.Windows.Forms.Button();
            this.grb_follow = new System.Windows.Forms.GroupBox();
            this.grb_user = new System.Windows.Forms.GroupBox();
            this.lbl_nick1 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_uname = new System.Windows.Forms.Label();
            this.pic_avatar = new System.Windows.Forms.PictureBox();
            this.grb_user.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_avatar)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 28);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(149, 55);
            this.button2.TabIndex = 2;
            this.button2.Text = "cefsharp";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // grb_follow
            // 
            this.grb_follow.Location = new System.Drawing.Point(12, 147);
            this.grb_follow.Name = "grb_follow";
            this.grb_follow.Size = new System.Drawing.Size(1276, 306);
            this.grb_follow.TabIndex = 3;
            this.grb_follow.TabStop = false;
            this.grb_follow.Text = "关注用户";
            // 
            // grb_user
            // 
            this.grb_user.Controls.Add(this.pic_avatar);
            this.grb_user.Controls.Add(this.lbl_uname);
            this.grb_user.Controls.Add(this.label1);
            this.grb_user.Controls.Add(this.lbl_nick1);
            this.grb_user.Location = new System.Drawing.Point(444, 28);
            this.grb_user.Name = "grb_user";
            this.grb_user.Size = new System.Drawing.Size(804, 113);
            this.grb_user.TabIndex = 4;
            this.grb_user.TabStop = false;
            this.grb_user.Text = "用户信息";
            // 
            // lbl_nick1
            // 
            this.lbl_nick1.AutoSize = true;
            this.lbl_nick1.Location = new System.Drawing.Point(30, 53);
            this.lbl_nick1.Name = "lbl_nick1";
            this.lbl_nick1.Size = new System.Drawing.Size(130, 24);
            this.lbl_nick1.TabIndex = 0;
            this.lbl_nick1.Text = "用户昵称：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(363, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "头像：";
            // 
            // lbl_uname
            // 
            this.lbl_uname.AutoSize = true;
            this.lbl_uname.Location = new System.Drawing.Point(166, 53);
            this.lbl_uname.Name = "lbl_uname";
            this.lbl_uname.Size = new System.Drawing.Size(0, 24);
            this.lbl_uname.TabIndex = 2;
            // 
            // pic_avatar
            // 
            this.pic_avatar.Location = new System.Drawing.Point(451, 27);
            this.pic_avatar.Name = "pic_avatar";
            this.pic_avatar.Size = new System.Drawing.Size(95, 80);
            this.pic_avatar.TabIndex = 3;
            this.pic_avatar.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1301, 854);
            this.Controls.Add(this.grb_user);
            this.Controls.Add(this.grb_follow);
            this.Controls.Add(this.button2);
            this.Name = "Form1";
            this.Text = "微商相册采集";
            this.grb_user.ResumeLayout(false);
            this.grb_user.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_avatar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox grb_follow;
        private System.Windows.Forms.GroupBox grb_user;
        private System.Windows.Forms.Label lbl_uname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_nick1;
        private System.Windows.Forms.PictureBox pic_avatar;
    }
}

