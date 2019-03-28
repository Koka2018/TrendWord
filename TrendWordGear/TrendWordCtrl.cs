using NMeCab;
using System.Collections.Generic;
using TrendWordGear.Model;

namespace TrendWordGear
{
    public class TrendWordCtrl
    {
        #region メンバ変数

        ///<summary> MeCabTagger </summary>
        private MeCabTagger mTagger = MeCabTagger.Create();

        #endregion

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public TrendWordCtrl()
        {
        }

        #region メソッド

        /// <summary>
        /// トークンテーブル取得処理
        /// </summary>
        /// <param name="text">テキスト</param>
        /// <returns>トークンテーブル</returns>
        public Dictionary<string, List<TokenData>> GetTokenTbl(string text)
        {
            var tokenTbl = new Dictionary<string, List<TokenData>>();

            var node = mTagger.ParseToNode(text);
            while(node != null)
            {
                var token = new TokenData(node.Surface, node.Feature);

                if(tokenTbl.ContainsKey(token.BasicWord) == false)
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
        public List<TokenData> GetTokenList(string text)
        {
            var tokenList = new List<TokenData>();

            var node = mTagger.ParseToNode(text);
            while (node != null)
            {
                tokenList.Add(new TokenData(node.Surface, node.Feature));

                node = node.Next;
            }

            return tokenList;
        }

        /// <summary>
        /// 段落（文の集合体）から文への変換
        /// </summary>
        /// <param name="paragram">段落</param>
        /// <returns>文リスト</returns>
        public List<string> SplitMultiSentence(string paragram)
        {
            return new List<string>(paragram.Split('。'));
        }

        #endregion
    }
}
