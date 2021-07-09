namespace Demo
{
    partial class MainForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button2 = new System.Windows.Forms.Button();
            this.grb_follow = new System.Windows.Forms.GroupBox();
            this.dgv_follows = new System.Windows.Forms.DataGridView();
            this.grb_user = new System.Windows.Forms.GroupBox();
            this.lbl_shop_id = new System.Windows.Forms.Label();
            this.label4d = new System.Windows.Forms.Label();
            this.lbl_shop_name = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pic_avatar = new System.Windows.Forms.PictureBox();
            this.lbl_uname = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_nick1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grb_follow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_follows)).BeginInit();
            this.grb_user.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_avatar)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Location = new System.Drawing.Point(9, 11);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(144, 59);
            this.button2.TabIndex = 2;
            this.button2.Text = "cefsharp";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // grb_follow
            // 
            this.grb_follow.Controls.Add(this.dgv_follows);
            this.grb_follow.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grb_follow.Location = new System.Drawing.Point(9, 224);
            this.grb_follow.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.grb_follow.Name = "grb_follow";
            this.grb_follow.Padding = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.grb_follow.Size = new System.Drawing.Size(1112, 591);
            this.grb_follow.TabIndex = 3;
            this.grb_follow.TabStop = false;
            this.grb_follow.Text = "关注用户";
            // 
            // dgv_follows
            // 
            this.dgv_follows.AllowUserToAddRows = false;
            this.dgv_follows.AllowUserToDeleteRows = false;
            this.dgv_follows.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_follows.ColumnHeadersHeight = 46;
            this.dgv_follows.Location = new System.Drawing.Point(4, 36);
            this.dgv_follows.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.dgv_follows.Name = "dgv_follows";
            this.dgv_follows.ReadOnly = true;
            this.dgv_follows.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgv_follows.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_follows.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgv_follows.RowTemplate.Height = 37;
            this.dgv_follows.Size = new System.Drawing.Size(1104, 547);
            this.dgv_follows.TabIndex = 0;
            this.dgv_follows.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_follows_CellContentClick);
            // 
            // grb_user
            // 
            this.grb_user.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.grb_user.Controls.Add(this.lbl_shop_id);
            this.grb_user.Controls.Add(this.label4d);
            this.grb_user.Controls.Add(this.lbl_shop_name);
            this.grb_user.Controls.Add(this.label2);
            this.grb_user.Controls.Add(this.pic_avatar);
            this.grb_user.Controls.Add(this.lbl_uname);
            this.grb_user.Controls.Add(this.label1);
            this.grb_user.Controls.Add(this.lbl_nick1);
            this.grb_user.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grb_user.Location = new System.Drawing.Point(322, 11);
            this.grb_user.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.grb_user.Name = "grb_user";
            this.grb_user.Padding = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.grb_user.Size = new System.Drawing.Size(782, 207);
            this.grb_user.TabIndex = 4;
            this.grb_user.TabStop = false;
            this.grb_user.Text = "用户信息";
            // 
            // lbl_shop_id
            // 
            this.lbl_shop_id.AutoSize = true;
            this.lbl_shop_id.Location = new System.Drawing.Point(448, 139);
            this.lbl_shop_id.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_shop_id.Name = "lbl_shop_id";
            this.lbl_shop_id.Size = new System.Drawing.Size(0, 27);
            this.lbl_shop_id.TabIndex = 7;
            // 
            // label4d
            // 
            this.label4d.AutoSize = true;
            this.label4d.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4d.Location = new System.Drawing.Point(325, 139);
            this.label4d.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4d.Name = "label4d";
            this.label4d.Size = new System.Drawing.Size(93, 27);
            this.label4d.TabIndex = 6;
            this.label4d.Text = "店铺ID：";
            // 
            // lbl_shop_name
            // 
            this.lbl_shop_name.AutoSize = true;
            this.lbl_shop_name.Location = new System.Drawing.Point(148, 136);
            this.lbl_shop_name.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_shop_name.Name = "lbl_shop_name";
            this.lbl_shop_name.Size = new System.Drawing.Size(0, 27);
            this.lbl_shop_name.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(17, 136);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 27);
            this.label2.TabIndex = 4;
            this.label2.Text = "店铺名称：";
            // 
            // pic_avatar
            // 
            this.pic_avatar.Location = new System.Drawing.Point(418, 39);
            this.pic_avatar.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.pic_avatar.Name = "pic_avatar";
            this.pic_avatar.Size = new System.Drawing.Size(92, 86);
            this.pic_avatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_avatar.TabIndex = 3;
            this.pic_avatar.TabStop = false;
            // 
            // lbl_uname
            // 
            this.lbl_uname.AutoSize = true;
            this.lbl_uname.Location = new System.Drawing.Point(162, 56);
            this.lbl_uname.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_uname.Name = "lbl_uname";
            this.lbl_uname.Size = new System.Drawing.Size(0, 27);
            this.lbl_uname.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(332, 67);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 27);
            this.label1.TabIndex = 1;
            this.label1.Text = "头像：";
            // 
            // lbl_nick1
            // 
            this.lbl_nick1.AutoSize = true;
            this.lbl_nick1.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_nick1.Location = new System.Drawing.Point(17, 56);
            this.lbl_nick1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_nick1.Name = "lbl_nick1";
            this.lbl_nick1.Size = new System.Drawing.Size(112, 27);
            this.lbl_nick1.TabIndex = 0;
            this.lbl_nick1.Text = "用户昵称：";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.grb_user);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.grb_follow);
            this.panel1.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1136, 837);
            this.panel1.TabIndex = 5;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1134, 845);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.Name = "MainForm";
            this.Text = "微商相册采集";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.grb_follow.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_follows)).EndInit();
            this.grb_user.ResumeLayout(false);
            this.grb_user.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_avatar)).EndInit();
            this.panel1.ResumeLayout(false);
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
        private System.Windows.Forms.Label lbl_shop_id;
        private System.Windows.Forms.Label label4d;
        private System.Windows.Forms.Label lbl_shop_name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgv_follows;
        private System.Windows.Forms.Panel panel1;
    }
}

