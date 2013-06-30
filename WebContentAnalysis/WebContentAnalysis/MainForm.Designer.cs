namespace WebContentAnalysis
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tbUrl = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbCount = new System.Windows.Forms.TextBox();
            this.getStart = new System.Windows.Forms.Button();
            this.tbImageFolder = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblProgress = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbUrl
            // 
            this.tbUrl.Location = new System.Drawing.Point(211, 64);
            this.tbUrl.Name = "tbUrl";
            this.tbUrl.Size = new System.Drawing.Size(531, 21);
            this.tbUrl.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "天猫列表页URL地址：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(101, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "下载单品个数：";
            // 
            // tbCount
            // 
            this.tbCount.Location = new System.Drawing.Point(211, 113);
            this.tbCount.Name = "tbCount";
            this.tbCount.Size = new System.Drawing.Size(100, 21);
            this.tbCount.TabIndex = 3;
            // 
            // getStart
            // 
            this.getStart.Location = new System.Drawing.Point(587, 362);
            this.getStart.Name = "getStart";
            this.getStart.Size = new System.Drawing.Size(75, 23);
            this.getStart.TabIndex = 4;
            this.getStart.Text = "开始获取";
            this.getStart.UseVisualStyleBackColor = true;
            this.getStart.Click += new System.EventHandler(this.getStart_Click);
            // 
            // tbImageFolder
            // 
            this.tbImageFolder.Location = new System.Drawing.Point(211, 161);
            this.tbImageFolder.Name = "tbImageFolder";
            this.tbImageFolder.Size = new System.Drawing.Size(421, 21);
            this.tbImageFolder.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(89, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "图片存放文件夹：";
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Location = new System.Drawing.Point(211, 254);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(0, 12);
            this.lblProgress.TabIndex = 7;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 486);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbImageFolder);
            this.Controls.Add(this.getStart);
            this.Controls.Add(this.tbCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbUrl);
            this.Name = "MainForm";
            this.Text = "天猫图片下载工具";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbUrl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbCount;
        private System.Windows.Forms.Button getStart;
        private System.Windows.Forms.TextBox tbImageFolder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblProgress;
    }
}

