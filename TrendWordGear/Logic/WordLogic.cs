using NMeCab;
using System.Collections.Generic;
using System.Linq;
using WordGear.Model;

namespace WordGear.Logic
{
    public static class WordLogic
    {
        #region メンバ変数

        ///<summary> MeCabTagger </summary>
        private static MeCabTagger sTagger = MeCabTagger.Create();

        #endregion

        #region メソッド

        /// <summary>
        /// トークンテーブル取得処理
        /// </summary>
        /// <param name="text">テキスト</param>
        /// <returns>トークンテーブル</returns>
        public static Dictionary<string, List<TokenData>> GetBasicTokenTbl(string text)
        {
            var tokenTbl = new Dictionary<string, List<TokenData>>();
            var tokenList = GetTokenList(text);
            foreach (var token in tokenList)
            {
                if (tokenTbl.ContainsKey(token.BasicWord) == false)
                {
                    tokenTbl[token.BasicWord] = new List<TokenData>();
                }
                tokenTbl[token.BasicWord].Add(token);
            }

            return tokenTbl;
        }

        /// <summary>
        /// トークンリスト取得処理
        /// </summary>
        /// <param name="text">テキスト</param>
        /// <returns>トークンリスト</returns>
        public static List<TokenData> GetTokenList(string text)
        {
            var tokenList = new List<TokenData>();

            var node = sTagger.ParseToNode(text.Replace("\0", ""));
            // 一つ目は原文が入っているため読み飛ばす
            node = node.Next;
            while (node != null)
            {
                tokenList.Add(new TokenData(node.Surface, node.Feature));

                node = node.Next;
            }

            //return RefineTokenList(tokenList);
            return tokenList;
        }

        /// <summary>
        /// トークンの品詞分類結果取得
        /// </summary>
        /// <param name="tokenList">トークンリスト</param>
        /// <returns>品詞分離結果</returns>
        public static Dictionary<string, List<TokenData>> GetTokenTypeTbl(List<TokenData> tokenList)
        {
            var tokenTypeTbl = new Dictionary<string, List<TokenData>>();

            foreach (var token in tokenList)
            {
                if (tokenTypeTbl.ContainsKey(token.Type) == false)
                {
                    tokenTypeTbl[token.Type] = new List<TokenData>();
                }
                tokenTypeTbl[token.Type].Add(token);
            }

            return tokenTypeTbl;
        }

        private static List<TokenData> RefineTokenList(List<TokenData> tokenList)
        {
            if (tokenList.Count == 0) { return tokenList; }

            var refinedTokenList = new List<TokenData>();
            refinedTokenList.Add(tokenList.First());
            for (int i = 1; i < tokenList.Count; i++)
            {
                if (refinedTokenList.Last().Type == "名詞"
                    && refinedTokenList.Last().Type == tokenList[i].Type)
                {
                    refinedTokenList[refinedTokenList.Count - 1] = refinedTokenList.Last() + tokenList[i];
                    continue;
                }
                refinedTokenList.Add(tokenList[i]);
            }

            return refinedTokenList;
        }

        #endregion
    }
}
