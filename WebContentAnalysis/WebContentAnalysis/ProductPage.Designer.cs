namespace WebContentAnalysis
{
    partial class ProductPage
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
            this.lblUrl = new System.Windows.Forms.Label();
            this.wbProduct = new System.Windows.Forms.WebBrowser();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblUrl
            // 
            this.lblUrl.AutoSize = true;
            this.lblUrl.Location = new System.Drawing.Point(13, 13);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(0, 12);
            this.lblUrl.TabIndex = 0;
            // 
            // wbProduct
            // 
            this.wbProduct.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.wbProduct.Location = new System.Drawing.Point(0, 46);
            this.wbProduct.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbProduct.Name = "wbProduct";
            this.wbProduct.Size = new System.Drawing.Size(956, 447);
            this.wbProduct.TabIndex = 1;
            this.wbProduct.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.wbProduct_DocumentCompleted);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(869, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ProductPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 493);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.wbProduct);
            this.Controls.Add(this.lblUrl);
            this.Name = "ProductPage";
            this.Text = "ProductPage";
            this.Load += new System.EventHandler(this.ProductPage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUrl;
        private System.Windows.Forms.WebBrowser wbProduct;
        private System.Windows.Forms.Button button1;
    }
}