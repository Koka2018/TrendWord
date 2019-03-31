using System.Collections.Generic;
using WordGear.Model;

namespace WordGear.Logic
{
    public static class AnalyzeLogic
    {
        /// <summary>
        /// 品詞指定によるトークンリスト抽出処理
        /// </summary>
        /// <param name="tokenList">トークンリスト</param>
        /// <param name="type">品詞</param>
        /// <returns>抽出したトークン</returns>
        public static List<TokenData> ExtractTokenType(List<TokenData> tokenList, string type)
        {
            var extractTokenList = new List<TokenData>();
            foreach (var token in tokenList)
            {
                if (token.Type == type)
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
        public static Dictionary<string, List<TokenData>> ExtractTokenType(Dictionary<string, List<TokenData>> tokenTbl, string type)
        {
            var extractTokenTbl = new Dictionary<string, List<TokenData>>();

            foreach (var key in tokenTbl.Keys)
            {
                if (tokenTbl[key][0].Type != type) { continue; }
                extractTokenTbl[key] = new List<TokenData>(tokenTbl[key]);
            }

            return extractTokenTbl;
        }
    }
}
