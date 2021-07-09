namespace Demo
{
    partial class BrowserForm
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
            this.chromeBrowser = new CefSharp.WinForms.ChromiumWebBrowser();
            this.SuspendLayout();
            // 
            // chromeBrowser
            // 
            this.chromeBrowser.ActivateBrowserOnCreation = false;
// TODO: “”的代码生成失败，原因是出现异常“无效的基元类型: System.IntPtr。请考虑使用 CodeObjectCreateExpression。”。
            this.chromeBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chromeBrowser.Location = new System.Drawing.Point(0, 0);
            this.chromeBrowser.Name = "chromeBrowser";
            this.chromeBrowser.Size = new System.Drawing.Size(1255, 852);
            this.chromeBrowser.TabIndex = 0;
            this.chromeBrowser.FrameLoadEnd += new System.EventHandler<CefSharp.FrameLoadEndEventArgs>(this.chromeBrowser_FrameLoadEnd);
            // 
            // BrowserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1255, 852);
            this.Controls.Add(this.chromeBrowser);
            this.Name = "BrowserForm";
            this.Text = "BrowserForm";
            this.ResumeLayout(false);

        }

        #endregion

        public CefSharp.WinForms.ChromiumWebBrowser chromeBrowser;
    }
}