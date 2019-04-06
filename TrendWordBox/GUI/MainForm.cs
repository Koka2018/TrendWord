using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WordGear;
using WordGear.Logic;

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
                mTxtResult.Text = string.Empty;
                var sb = new StringBuilder();
                var ctrl = new WordCtrl();

                ctrl.Analyze(mTxtTgtText.Text);
                sb.AppendLine("====================");
                sb.AppendFormat("情報量={0:#.#}[%]", ctrl.InfoRate * 100).AppendLine();
                sb.AppendLine("====================");
                foreach (var key in ctrl.TokenTypeTbl.Keys)
                {
                    sb.AppendLine(string.Format("\t=== {0} ===", key));
                    var extractTokenTbl = AnalyzeLogic.ExtractTokenType(ctrl.TokenTbl, key);
                    foreach (var token in extractTokenTbl.Keys)
                    {
                        sb.AppendLine(string.Format("\t\t{0}: {1}",
                                                    token.Replace("\0", ""),
                                                    extractTokenTbl[token].Count()));
                    }
                }
                foreach (var paragraph in ctrl.ParagraphList)
                {
                    sb.AppendLine("------------------------------");
                    sb.AppendLine(paragraph.Text);
                    sb.AppendFormat("情報量={0:#.#}[%]", paragraph.InfoRate * 100).AppendLine();
                    foreach(var key in paragraph.TokenTypeTbl.Keys)
                    {
                        sb.AppendLine(string.Format("\t=== {0} ===", key));
                        var extractTokenTbl = AnalyzeLogic.ExtractTokenType(paragraph.TokenTbl, key);
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
