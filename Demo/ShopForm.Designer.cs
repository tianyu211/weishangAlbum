
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
            ((System.ComponentModel.ISupportInitialize)(this.dgv_shop)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_shop
            // 
            this.dgv_shop.AllowUserToAddRows = false;
            this.dgv_shop.AllowUserToDeleteRows = false;
            this.dgv_shop.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_shop.Location = new System.Drawing.Point(12, 40);
            this.dgv_shop.Name = "dgv_shop";
            this.dgv_shop.ReadOnly = true;
            this.dgv_shop.RowHeadersWidth = 82;
            this.dgv_shop.RowTemplate.Height = 37;
            this.dgv_shop.Size = new System.Drawing.Size(1124, 727);
            this.dgv_shop.TabIndex = 0;
            // 
            // ShopForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1148, 779);
            this.Controls.Add(this.dgv_shop);
            this.Name = "ShopForm";
            this.Text = "ShopForm";
            this.Load += new System.EventHandler(this.ShopForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_shop)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_shop;
    }
}