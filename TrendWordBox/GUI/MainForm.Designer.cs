namespace TrendWordBox
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOpenFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.mTxtTgtText = new System.Windows.Forms.TextBox();
            this.mTxtResult = new System.Windows.Forms.TextBox();
            this.mwnuSentenceAnalyzeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(484, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuFileToolStripMenuItem
            // 
            this.menuFileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuOpenFileToolStripMenuItem,
            this.mwnuSentenceAnalyzeToolStripMenuItem});
            this.menuFileToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.menuFileToolStripMenuItem.Name = "menuFileToolStripMenuItem";
            this.menuFileToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.menuFileToolStripMenuItem.Text = "ファイル(&F)";
            // 
            // menuOpenFileToolStripMenuItem
            // 
            this.menuOpenFileToolStripMenuItem.Name = "menuOpenFileToolStripMenuItem";
            this.menuOpenFileToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.menuOpenFileToolStripMenuItem.Text = "ファイル選択";
            this.menuOpenFileToolStripMenuItem.Click += new System.EventHandler(this.menuOpenFileToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.mTxtTgtText);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.mTxtResult);
            this.splitContainer1.Size = new System.Drawing.Size(484, 337);
            this.splitContainer1.SplitterDistance = 228;
            this.splitContainer1.TabIndex = 1;
            // 
            // mTxtTgtText
            // 
            this.mTxtTgtText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.mTxtTgtText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mTxtTgtText.ForeColor = System.Drawing.Color.White;
            this.mTxtTgtText.Location = new System.Drawing.Point(0, 0);
            this.mTxtTgtText.Multiline = true;
            this.mTxtTgtText.Name = "mTxtTgtText";
            this.mTxtTgtText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.mTxtTgtText.Size = new System.Drawing.Size(228, 337);
            this.mTxtTgtText.TabIndex = 0;
            // 
            // mTxtResult
            // 
            this.mTxtResult.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.mTxtResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mTxtResult.ForeColor = System.Drawing.Color.White;
            this.mTxtResult.Location = new System.Drawing.Point(0, 0);
            this.mTxtResult.Multiline = true;
            this.mTxtResult.Name = "mTxtResult";
            this.mTxtResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.mTxtResult.Size = new System.Drawing.Size(252, 337);
            this.mTxtResult.TabIndex = 1;
            // 
            // mwnuSentenceAnalyzeToolStripMenuItem
            // 
            this.mwnuSentenceAnalyzeToolStripMenuItem.Name = "mwnuSentenceAnalyzeToolStripMenuItem";
            this.mwnuSentenceAnalyzeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.mwnuSentenceAnalyzeToolStripMenuItem.Text = "文章解析";
            this.mwnuSentenceAnalyzeToolStripMenuItem.Click += new System.EventHandler(this.mwnuSentenceAnalyzeToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(484, 361);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.Color.Black;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "TrendWordBox";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuOpenFileToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox mTxtTgtText;
        private System.Windows.Forms.TextBox mTxtResult;
        private System.Windows.Forms.ToolStripMenuItem mwnuSentenceAnalyzeToolStripMenuItem;
    }
}

