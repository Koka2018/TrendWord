﻿using System.Collections.Generic;
using WordGear.Model;
using WordGear.Logic;

namespace WordGear
{
    public class WordCtrl
    {
        #region プロパティ

        public string Text { get; private set; }
        public List<ParagraphData> ParagraphList { get; private set; }
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
        public WordCtrl()
        {
            Text = string.Empty;
            ParagraphList = new List<ParagraphData>();
            TokenList = new List<TokenData>();
            TokenTbl = new Dictionary<string, List<TokenData>>();
            TokenTypeTbl = new Dictionary<string, List<TokenData>>();
            InfoRate = 0.0;
        }

        #region メソッド

        /// <summary>
        /// 解析処理
        /// </summary>
        /// <param name="text">テキスト</param>
        public void Analyze(string text)
        {
            ParagraphList.Clear();

            var strParagraphList = ParagraphLogic.SplitParagraph(text);
            foreach(var strParagraph in strParagraphList)
            {
                ParagraphList.Add(new ParagraphData(strParagraph));
            }

            TokenList = WordLogic.GetTokenList(text);
            TokenTbl = WordLogic.GetBasicTokenTbl(text);
            TokenTypeTbl = WordLogic.GetTokenTypeTbl(TokenList);
            InfoRate = AnalyzeLogic.CalcInfoRate(TokenList);
        }

        #endregion
    }
}
