using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using WordGear;

namespace TrendWordBox
{
    public partial class MainForm : Form
    {
        #region メンバ変数

        private WordCtrl mWordCtrl = new WordCtrl();

        #endregion

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        #region メインメニュー

        /// <summary>
        /// メインメニュー：ファイル > ファイル選択
        /// </summary>
        /// <param name="sender">送信元</param>
        /// <param name="e">イベント</param>
        private void menuOpenFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (var dlg = new OpenFileDialog()
                {
                    Filter = "テキスト|*.txt|すべてのファイル|*"
                })
                {
                    if(dlg.ShowDialog() != DialogResult.OK) { return; }

                    mTxtTgtText.Text = File.ReadAllText(dlg.FileName, Encoding.Default);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// メインメニュー：ファイル > 文章解析
        /// </summary>
        /// <param name="sender">送信元</param>
        /// <param name="e">イベント</param>
        private void mwnuSentenceAnalyzeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var sentenceList = mWordCtrl.SplitParagraph(mTxtTgtText.Text);

                mTxtResult.Text = string.Empty;

                var sb = new StringBuilder();
                foreach(var sentence in sentenceList)
                {
                    var tokenList = mWordCtrl.GetTokenList(sentence);
                    var tokenTbl = mWordCtrl.GetBasicTokenTbl(sentence);
                    var tokenTypeTb = mWordCtrl.GetTokenTypeTbl(tokenList);

                    sb.AppendLine("------------------------------");
                    sb.AppendLine(sentence);
                    foreach(var key in tokenTypeTb.Keys)
                    {
                        sb.AppendLine(string.Format("\t=== {0} ===", key));
                        var extractTokenTbl = mWordCtrl.ExtractTokenType(tokenTbl, key);
                        foreach(var token in extractTokenTbl.Keys)
                        {
                            sb.AppendLine(string.Format("\t\t{0}: {1}",
                                                        token.Replace("\0", ""),
                                                        extractTokenTbl[token].Count()));
                            //foreach(var word in extractTokenTbl[token])
                            //{
                            //    sb.AppendLine(string.Format("\t\t\t{0}", word.Word));
                            //}
                        }
                    }
                }
                mTxtResult.Text = sb.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion
    }
}
