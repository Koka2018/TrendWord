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

        #region 形態素解析メソッド

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
        /// 段落（文の集合体）から文への変換
        /// </summary>
        /// <param name="paragram">段落</param>
        /// <returns>文リスト</returns>
        public List<string> SplitMultiSentence(string paragram)
        {
            return new List<string>(paragram.Split('。'));
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
