﻿using System.Collections.Generic;
using WordGear.Model;
using WordGear.Logic;

namespace WordGear
{
    public class WordCtrl
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public WordCtrl()
        {
        }

        #region 形態素解析メソッド

        /// <summary>
        /// トークンテーブル取得処理
        /// </summary>
        /// <param name="text">テキスト</param>
        /// <returns>トークンテーブル</returns>
        public Dictionary<string, List<TokenData>> GetBasicTokenTbl(string text)
            => WordLogic.GetBasicTokenTbl(text);

        /// <summary>
        /// トークンリスト取得処理
        /// </summary>
        /// <param name="text">テキスト</param>
        /// <returns>トークンリスト</returns>
        public List<TokenData> GetTokenList(string text)
            => WordLogic.GetTokenList(text);

        /// <summary>
        /// トークンの品詞分類結果取得
        /// </summary>
        /// <param name="tokenList">トークンリスト</param>
        /// <returns>品詞分離結果</returns>
        public Dictionary<string, List<TokenData>> GetTokenTypeTbl(List<TokenData> tokenList)
            => WordLogic.GetTokenTypeTbl(tokenList);

        #endregion

        #region 文章メソッド

        /// <summary>
        /// 文の切り出し処理
        /// </summary>
        /// <param name="paragraph">文章</param>
        /// <returns>文リスト</returns>
        public List<string> SplitParagraph(string paragraph)
        {
            var sentenceList = new List<string>(paragraph.Split('。'));

            return sentenceList;
        }

        #endregion

        #region 集計メソッド

        /// <summary>
        /// 品詞指定によるトークンリスト抽出処理
        /// </summary>
        /// <param name="tokenList">トークンリスト</param>
        /// <param name="type">品詞</param>
        /// <returns>抽出したトークン</returns>
        public List<TokenData> ExtractTokenType(List<TokenData> tokenList, string type)
        {
            var extractTokenList = new List<TokenData>();
            foreach(var token in tokenList)
            {
                if(token.Type == type)
                {
                    extractTokenList.Add(token);
                }
            }

            return extractTokenList;
        }

        /// <summary>
        /// 品詞指定によるトークンテーブル抽出処理
        /// </summary>
        /// <param name="tokenTbl">トークンテーブル</param>
        /// <param name="type">品詞</param>
        /// <returns>抽出したトークンテーブル</returns>
        public Dictionary<string, List<TokenData>> ExtractTokenType(Dictionary<string, List<TokenData>> tokenTbl, string type)
        {
            var extractTokenTbl = new Dictionary<string, List<TokenData>>();

            foreach(var key in tokenTbl.Keys)
            {
                if(tokenTbl[key][0].Type != type) { continue; }
                extractTokenTbl[key] = new List<TokenData>(tokenTbl[key]);
            }

            return extractTokenTbl;
        }

        #endregion
    }
}