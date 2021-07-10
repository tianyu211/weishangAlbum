
namespace Demo
{
    partial class ShopForm
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
            this.dgv_shop = new System.Windows.Forms.DataGridView();
            this.btn_pre = new System.Windows.Forms.Button();
            this.btn_next = new System.Windows.Forms.Button();
            this.Cbx_pageSize = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_shop)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_shop
            // 
            this.dgv_shop.AllowUserToAddRows = false;
            this.dgv_shop.AllowUserToDeleteRows = false;
            this.dgv_shop.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_shop.Location = new System.Drawing.Point(12, 12);
            this.dgv_shop.Name = "dgv_shop";
            this.dgv_shop.ReadOnly = true;
            this.dgv_shop.RowHeadersWidth = 82;
            this.dgv_shop.RowTemplate.Height = 37;
            this.dgv_shop.Size = new System.Drawing.Size(1618, 900);
            this.dgv_shop.TabIndex = 0;
            // 
            // btn_pre
            // 
            this.btn_pre.Location = new System.Drawing.Point(505, 918);
            this.btn_pre.Name = "btn_pre";
            this.btn_pre.Size = new System.Drawing.Size(125, 44);
            this.btn_pre.TabIndex = 1;
            this.btn_pre.Text = "上一页";
            this.btn_pre.UseVisualStyleBackColor = true;
            this.btn_pre.Click += new System.EventHandler(this.btn_pre_Click);
            // 
            // btn_next
            // 
            this.btn_next.Location = new System.Drawing.Point(1002, 918);
            this.btn_next.Name = "btn_next";
            this.btn_next.Size = new System.Drawing.Size(125, 44);
            this.btn_next.TabIndex = 2;
            this.btn_next.Text = "下一页";
            this.btn_next.UseVisualStyleBackColor = true;
            this.btn_next.Click += new System.EventHandler(this.btn_next_Click);
            // 
            // Cbx_pageSize
            // 
            this.Cbx_pageSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cbx_pageSize.FormattingEnabled = true;
            this.Cbx_pageSize.Items.AddRange(new object[] {
            "10",
            "15",
            "20",
            "50",
            "100"});
            this.Cbx_pageSize.Location = new System.Drawing.Point(780, 925);
            this.Cbx_pageSize.Name = "Cbx_pageSize";
            this.Cbx_pageSize.Size = new System.Drawing.Size(150, 32);
            this.Cbx_pageSize.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(692, 928);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "每页：";
            // 
            // ShopForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1642, 974);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Cbx_pageSize);
            this.Controls.Add(this.btn_next);
            this.Controls.Add(this.btn_pre);
            this.Controls.Add(this.dgv_shop);
            this.Name = "ShopForm";
            this.Text = "ShopForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ShopForm_FormClosed);
            this.Load += new System.EventHandler(this.ShopForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_shop)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_shop;
        private System.Windows.Forms.Button btn_pre;
        private System.Windows.Forms.Button btn_next;
        private System.Windows.Forms.ComboBox Cbx_pageSize;
        private System.Windows.Forms.Label label1;
    }
}