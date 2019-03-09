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
            var tbl = new Dictionary<string, List<TokenData>>();

            var node = mTagger.ParseToNode(text);
            while(node != null)
            {
                var token = new TokenData(node.Surface, node.Feature);

                if(tbl.ContainsKey(token.BasicWord) == false)
                {
                    tbl[token.BasicWord] = new List<TokenData>();
                }
                tbl[token.BasicWord].Add(token);

                node = node.Next;
            }

            return tbl;
        }

        #endregion
    }
}
