using System.Collections.Generic;
using WordGear.Logic;

namespace WordGear.Model
{
    public class ParagraphData
    {
        #region プロパティ

        ///<summary> テキスト </summary>
        public string Text { get; private set; }
        ///<summary> トークンリスト </summary>
        public List<TokenData> TokenList { get; private set; }
        ///<summary> トークンテーブル </summary>
        public Dictionary<string, List<TokenData>> TokenTbl { get; private set; }
        ///<summary> 品詞テーブル </summary>
        public Dictionary<string, List<TokenData>> TokenTypeTbl { get; private set; }
        ///<summary> 情報量 </summary>
        public double InfoRate { get; private set; }

        #endregion

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="text">テキスト</param>
        public ParagraphData(string text)
        {
            Text = text;
            TokenList = WordLogic.GetTokenList(text);
            TokenTbl = WordLogic.GetBasicTokenTbl(text);
            TokenTypeTbl = WordLogic.GetTokenTypeTbl(TokenList);
            InfoRate = AnalyzeLogic.CalcInfoRate(TokenList);
        }
    }
}
