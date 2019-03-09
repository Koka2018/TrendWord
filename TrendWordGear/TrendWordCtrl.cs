using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NMeCab;

namespace TrendWordGear
{
    public class TrendWordCtrl
    {
        #region 定数

        private enum EnumMeCabIdx
        {
            Type = 0,       // 品詞
            DetailType1,   // 品詞細分類1
            DetailType2,   // 品詞細分類2
            DetailType3,   // 品詞細分類3
            Adapted,        // 活用形
            AdaptType,     // 活用型
            Basic,             // 原形
            WayOfRead,    // 読み
            Pronunciation, // 発音
        }

        #endregion

        #region メンバ変数

        private MeCabTagger mTagger = MeCabTagger.Create();

        #endregion

        public TrendWordCtrl()
        {
        }

        #region メソッド

        public Dictionary<string, int> GetWordCntTbl(string text)
        {
            var tbl = new Dictionary<string, int>();

            var node = mTagger.ParseToNode(text);
            while(node != null)
            {
                var sp_Feature = node.Feature.Split(',');
                if (sp_Feature[(int)EnumMeCabIdx.Basic] != "*"
                    && node.Surface != sp_Feature[(int)EnumMeCabIdx.Basic])
                {
                    Console.WriteLine(node.Surface + " : " + sp_Feature[(int)EnumMeCabIdx.Basic]
                                                + node.Feature.Replace(",", "\t"));
                }
                node = node.Next;
            }

            return tbl;
        }

        #endregion
    }
}
