namespace WindowsFormsApplication
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.tbFolder = new System.Windows.Forms.TextBox();
            this.tbVGaoTargStr = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbPackageAddStr = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbKuguoTargStr = new System.Windows.Forms.TextBox();
            this.cbVGaoAdd = new System.Windows.Forms.CheckBox();
            this.cbKuGuoAdd = new System.Windows.Forms.CheckBox();
            this.cbReVGao = new System.Windows.Forms.CheckBox();
            this.cbReKuguo = new System.Windows.Forms.CheckBox();
            this.cbReGame = new System.Windows.Forms.CheckBox();
            this.btnAddCode = new System.Windows.Forms.Button();
            this.btnReplaceID = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbKuguoID = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbVGaoID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbApkName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbWQAdd = new System.Windows.Forms.CheckBox();
            this.btnModWQ = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tbCnt = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "工作路径：";
            // 
            // tbFolder
            // 
            this.tbFolder.Location = new System.Drawing.Point(117, 53);
            this.tbFolder.Name = "tbFolder";
            this.tbFolder.Size = new System.Drawing.Size(374, 21);
            this.tbFolder.TabIndex = 1;
            this.tbFolder.Text = "E:\\asus\\Android\\apktool";
            // 
            // tbVGaoTargStr
            // 
            this.tbVGaoTargStr.Location = new System.Drawing.Point(364, 99);
            this.tbVGaoTargStr.Name = "tbVGaoTargStr";
            this.tbVGaoTargStr.Size = new System.Drawing.Size(178, 21);
            this.tbVGaoTargStr.TabIndex = 5;
            this.tbVGaoTargStr.Text = "com.vgqc.";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(399, 283);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "开始";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(548, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "后边带【.】";
            // 
            // tbPackageAddStr
            // 
            this.tbPackageAddStr.Location = new System.Drawing.Point(290, 184);
            this.tbPackageAddStr.Name = "tbPackageAddStr";
            this.tbPackageAddStr.Size = new System.Drawing.Size(100, 21);
            this.tbPackageAddStr.TabIndex = 9;
            this.tbPackageAddStr.Text = "xxx";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(397, 192);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(329, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "如果元游戏包名为\"com.abc.game\"，即变为“com.xxx.game”";
            // 
            // tbKuguoTargStr
            // 
            this.tbKuguoTargStr.Location = new System.Drawing.Point(451, 136);
            this.tbKuguoTargStr.Name = "tbKuguoTargStr";
            this.tbKuguoTargStr.Size = new System.Drawing.Size(178, 21);
            this.tbKuguoTargStr.TabIndex = 5;
            this.tbKuguoTargStr.Text = "com.kgqc.demo.Childkkk";
            // 
            // cbVGaoAdd
            // 
            this.cbVGaoAdd.AutoSize = true;
            this.cbVGaoAdd.Location = new System.Drawing.Point(48, 101);
            this.cbVGaoAdd.Name = "cbVGaoAdd";
            this.cbVGaoAdd.Size = new System.Drawing.Size(78, 16);
            this.cbVGaoAdd.TabIndex = 11;
            this.cbVGaoAdd.Text = "添加V告包";
            this.cbVGaoAdd.UseVisualStyleBackColor = true;
            // 
            // cbKuGuoAdd
            // 
            this.cbKuGuoAdd.AutoSize = true;
            this.cbKuGuoAdd.Location = new System.Drawing.Point(48, 138);
            this.cbKuGuoAdd.Name = "cbKuGuoAdd";
            this.cbKuGuoAdd.Size = new System.Drawing.Size(84, 16);
            this.cbKuGuoAdd.TabIndex = 11;
            this.cbKuGuoAdd.Text = "添加酷果包";
            this.cbKuGuoAdd.UseVisualStyleBackColor = true;
            // 
            // cbReVGao
            // 
            this.cbReVGao.AutoSize = true;
            this.cbReVGao.Location = new System.Drawing.Point(163, 101);
            this.cbReVGao.Name = "cbReVGao";
            this.cbReVGao.Size = new System.Drawing.Size(168, 16);
            this.cbReVGao.TabIndex = 11;
            this.cbReVGao.Text = "V告包（com.va.）替换为：";
            this.cbReVGao.UseVisualStyleBackColor = true;
            // 
            // cbReKuguo
            // 
            this.cbReKuguo.AutoSize = true;
            this.cbReKuguo.Location = new System.Drawing.Point(163, 138);
            this.cbReKuguo.Name = "cbReKuguo";
            this.cbReKuguo.Size = new System.Drawing.Size(288, 16);
            this.cbReKuguo.TabIndex = 11;
            this.cbReKuguo.Text = "酷果包（com.kuguo.demo.ChildOfMain）替换为：";
            this.cbReKuguo.UseVisualStyleBackColor = true;
            // 
            // cbReGame
            // 
            this.cbReGame.AutoSize = true;
            this.cbReGame.Location = new System.Drawing.Point(163, 186);
            this.cbReGame.Name = "cbReGame";
            this.cbReGame.Size = new System.Drawing.Size(102, 16);
            this.cbReGame.TabIndex = 11;
            this.cbReGame.Text = "游戏包替换为:";
            this.cbReGame.UseVisualStyleBackColor = true;
            // 
            // btnAddCode
            // 
            this.btnAddCode.Location = new System.Drawing.Point(693, 283);
            this.btnAddCode.Name = "btnAddCode";
            this.btnAddCode.Size = new System.Drawing.Size(75, 23);
            this.btnAddCode.TabIndex = 12;
            this.btnAddCode.Text = "增加版本号";
            this.btnAddCode.UseVisualStyleBackColor = true;
            this.btnAddCode.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnReplaceID
            // 
            this.btnReplaceID.Location = new System.Drawing.Point(403, 95);
            this.btnReplaceID.Name = "btnReplaceID";
            this.btnReplaceID.Size = new System.Drawing.Size(75, 23);
            this.btnReplaceID.TabIndex = 13;
            this.btnReplaceID.Text = "替换";
            this.btnReplaceID.UseVisualStyleBackColor = true;
            this.btnReplaceID.Click += new System.EventHandler(this.btnReplaceID_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbKuguoID);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.tbVGaoID);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbApkName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnReplaceID);
            this.groupBox1.Location = new System.Drawing.Point(48, 312);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(494, 124);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "替换广告号";
            // 
            // tbKuguoID
            // 
            this.tbKuguoID.Location = new System.Drawing.Point(115, 77);
            this.tbKuguoID.Name = "tbKuguoID";
            this.tbKuguoID.Size = new System.Drawing.Size(260, 21);
            this.tbKuguoID.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 14;
            this.label6.Text = "酷果广告号：";
            // 
            // tbVGaoID
            // 
            this.tbVGaoID.Location = new System.Drawing.Point(115, 50);
            this.tbVGaoID.Name = "tbVGaoID";
            this.tbVGaoID.Size = new System.Drawing.Size(260, 21);
            this.tbVGaoID.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 12);
            this.label4.TabIndex = 14;
            this.label4.Text = "V告广告号：";
            // 
            // tbApkName
            // 
            this.tbApkName.Location = new System.Drawing.Point(115, 23);
            this.tbApkName.Name = "tbApkName";
            this.tbApkName.Size = new System.Drawing.Size(216, 21);
            this.tbApkName.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 12);
            this.label3.TabIndex = 14;
            this.label3.Text = "apk文件名：";
            // 
            // cbWQAdd
            // 
            this.cbWQAdd.AutoSize = true;
            this.cbWQAdd.Checked = true;
            this.cbWQAdd.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbWQAdd.Location = new System.Drawing.Point(48, 231);
            this.cbWQAdd.Name = "cbWQAdd";
            this.cbWQAdd.Size = new System.Drawing.Size(72, 16);
            this.cbWQAdd.TabIndex = 11;
            this.cbWQAdd.Text = "添加帷千";
            this.cbWQAdd.UseVisualStyleBackColor = true;
            // 
            // btnModWQ
            // 
            this.btnModWQ.Location = new System.Drawing.Point(544, 283);
            this.btnModWQ.Name = "btnModWQ";
            this.btnModWQ.Size = new System.Drawing.Size(75, 23);
            this.btnModWQ.TabIndex = 15;
            this.btnModWQ.Text = "修改帷千";
            this.btnModWQ.UseVisualStyleBackColor = true;
            this.btnModWQ.Click += new System.EventHandler(this.btnModWQ_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(639, 407);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 16;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // tbCnt
            // 
            this.tbCnt.Location = new System.Drawing.Point(117, 267);
            this.tbCnt.Name = "tbCnt";
            this.tbCnt.Size = new System.Drawing.Size(82, 21);
            this.tbCnt.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(70, 270);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 7;
            this.label7.Text = "次数：";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 487);
            this.Controls.Add(this.tbCnt);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnModWQ);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnAddCode);
            this.Controls.Add(this.cbReGame);
            this.Controls.Add(this.cbReKuguo);
            this.Controls.Add(this.cbWQAdd);
            this.Controls.Add(this.cbKuGuoAdd);
            this.Controls.Add(this.cbReVGao);
            this.Controls.Add(this.cbVGaoAdd);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbPackageAddStr);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.tbKuguoTargStr);
            this.Controls.Add(this.tbVGaoTargStr);
            this.Controls.Add(this.tbFolder);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "包名替换";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbFolder;
        private System.Windows.Forms.TextBox tbVGaoTargStr;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbPackageAddStr;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbKuguoTargStr;
        private System.Windows.Forms.CheckBox cbVGaoAdd;
        private System.Windows.Forms.CheckBox cbKuGuoAdd;
        private System.Windows.Forms.CheckBox cbReVGao;
        private System.Windows.Forms.CheckBox cbReKuguo;
        private System.Windows.Forms.CheckBox cbReGame;
        private System.Windows.Forms.Button btnAddCode;
        private System.Windows.Forms.Button btnReplaceID;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbKuguoID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbVGaoID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbApkName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbWQAdd;
        private System.Windows.Forms.Button btnModWQ;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbCnt;
        private System.Windows.Forms.Label label7;
    }
}

