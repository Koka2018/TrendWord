using System;
using System.Collections.Generic;
using TrendWordGear;
using TrendWordGear.Model;

namespace TrendWordBox
{
    class Program
    {
        static string DEBUG_TITLE = "\r\n=== {0} ===";

        static void Main(string[] args)
        {
            var ctrl = new TrendWordCtrl();
            var inputText = "MeCabは 京都大学情報学研究科−日本電信電話株式会社コミュニケーション科学基礎研究所 共同研究ユニットプロジェクトを通じて開発されたオープンソース 形態素解析エンジンです。 言語, 辞書,コーパスに依存しない汎用的な設計を 基本方針としています。 パラメータの推定に Conditional Random Fields (CRF) を用 いており, ChaSenが採用している 隠れマルコフモデルに比べ性能が向上しています。また、平均的に ChaSen, Juman, KAKASIより高速に動作します。 ちなみに和布蕪(めかぶ)は, 作者の好物です。  ";

            var tokenTbl = ctrl.GetBasicTokenTbl(inputText);

            //Console.WriteLine(string.Format(DEBUG_TITLE, "トークンテーブル"));
            //foreach(var basicWord in tokenTbl.Keys)
            //{
            //    Console.WriteLine(basicWord + "\t" + tokenTbl[basicWord].Count);
            //}

            var tokenList = ctrl.GetTokenList(inputText);

            Console.WriteLine(string.Format(DEBUG_TITLE, "トークンリスト"));
            foreach (var token in tokenList)
            {
                Console.WriteLine(string.Format("{0}: {1}: {2}: {3}",
                                                token.BasicWord,
                                                token.Type,
                                                token.Word,
                                                token.Feature));
            }

            //var nounList = ctrl.ExtractTokenType(tokenList, "名詞");
            //Console.WriteLine(string.Format(DEBUG_TITLE, "名詞抽出"));
            //foreach(var token in nounList)
            //{
            //    Console.WriteLine(string.Format("{0}: {1}: {2}",
            //                                    token.BasicWord,
            //                                    token.Type,
            //                                    token.Word));
            //}

            var tokenTypeTbl = ctrl.GetTokenTypeTbl(tokenList);
            Console.WriteLine(string.Format(DEBUG_TITLE, "品詞分類結果"));
            foreach (var key in tokenTypeTbl.Keys)
            {
                Console.WriteLine(string.Format("{0}: {1}",
                                                key,
                                                tokenTypeTbl[key].Count));
            }

            foreach (var key in tokenTypeTbl.Keys)
            {
                ExtractTokenType(ctrl, tokenTbl, key);
            }

            Console.ReadLine();
        }

        static void ExtractTokenType(TrendWordCtrl ctrl, Dictionary<string, List<TokenData>> tokenTbl, string tokenType)
        {
            var adjectiveTbl = ctrl.ExtractTokenType(tokenTbl, tokenType);
            Console.WriteLine(string.Format(DEBUG_TITLE, tokenType + "抽出"));
            foreach (var key in adjectiveTbl.Keys)
            {
                Console.WriteLine(string.Format("{0}: {1}",
                                                key,
                                                adjectiveTbl[key].Count));
            }
        }
    }
}
