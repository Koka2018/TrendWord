using NMeCab;
using System.Collections.Generic;
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

            var node = sTagger.ParseToNode(text);
            node = node.Next;
            while (node != null)
            {
                var token = new TokenData(node.Surface, node.Feature);

                if (tokenTbl.ContainsKey(token.BasicWord) == false)
                {
                    tokenTbl[token.BasicWord] = new List<TokenData>();
                }
                tokenTbl[token.BasicWord].Add(token);

                node = node.Next;
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

            var node = sTagger.ParseToNode(text);
            // 一つ目は原文が入っているため読み飛ばす
            node = node.Next;
            while (node != null)
            {
                tokenList.Add(new TokenData(node.Surface, node.Feature));

                node = node.Next;
            }

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

        #endregion
    }
}
