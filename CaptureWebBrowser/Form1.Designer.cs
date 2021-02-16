namespace CaptureWebBrowser
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.m_wbBrowser = new System.Windows.Forms.WebBrowser();
            this.m_bGo = new System.Windows.Forms.Button();
            this.m_bCapture = new System.Windows.Forms.Button();
            this.m_tbURL = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.m_folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.m_tbMessage = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_wbBrowser
            // 
            this.m_wbBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_wbBrowser.Location = new System.Drawing.Point(0, 0);
            this.m_wbBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.m_wbBrowser.Name = "m_wbBrowser";
            this.m_wbBrowser.Size = new System.Drawing.Size(1476, 546);
            this.m_wbBrowser.TabIndex = 0;
            this.m_wbBrowser.Url = new System.Uri("http://www.google.com", System.UriKind.Absolute);
            // 
            // m_bGo
            // 
            this.m_bGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_bGo.Location = new System.Drawing.Point(1014, 13);
            this.m_bGo.Name = "m_bGo";
            this.m_bGo.Size = new System.Drawing.Size(75, 23);
            this.m_bGo.TabIndex = 1;
            this.m_bGo.Text = "Go";
            this.m_bGo.UseVisualStyleBackColor = true;
            this.m_bGo.Click += new System.EventHandler(this.m_bGo_Click);
            // 
            // m_bCapture
            // 
            this.m_bCapture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_bCapture.Location = new System.Drawing.Point(1014, 42);
            this.m_bCapture.Name = "m_bCapture";
            this.m_bCapture.Size = new System.Drawing.Size(75, 23);
            this.m_bCapture.TabIndex = 2;
            this.m_bCapture.Text = "Capture";
            this.m_bCapture.UseVisualStyleBackColor = true;
            this.m_bCapture.Click += new System.EventHandler(this.m_bCapture_Click);
            // 
            // m_tbURL
            // 
            this.m_tbURL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_tbURL.Location = new System.Drawing.Point(46, 13);
            this.m_tbURL.Name = "m_tbURL";
            this.m_tbURL.Size = new System.Drawing.Size(952, 22);
            this.m_tbURL.TabIndex = 3;
            this.m_tbURL.Text = "www.google.com";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "URL";
            // 
            // m_tbMessage
            // 
            this.m_tbMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_tbMessage.Location = new System.Drawing.Point(46, 41);
            this.m_tbMessage.Name = "m_tbMessage";
            this.m_tbMessage.ReadOnly = true;
            this.m_tbMessage.Size = new System.Drawing.Size(952, 22);
            this.m_tbMessage.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_wbBrowser);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1476, 546);
            this.panel1.TabIndex = 6;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 546);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1476, 10);
            this.splitter1.TabIndex = 7;
            this.splitter1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.m_tbURL);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.m_tbMessage);
            this.panel2.Controls.Add(this.m_bGo);
            this.panel2.Controls.Add(this.m_bCapture);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 556);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1476, 72);
            this.panel2.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1476, 628);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser m_wbBrowser;
        private System.Windows.Forms.Button m_bGo;
        private System.Windows.Forms.Button m_bCapture;
        private System.Windows.Forms.TextBox m_tbURL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog m_folderBrowserDialog;
        private System.Windows.Forms.TextBox m_tbMessage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel2;
    }
}

