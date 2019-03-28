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
            //var inputText = "MeCabは 京都大学情報学研究科−日本電信電話株式会社コミュニケーション科学基礎研究所 共同研究ユニットプロジェクトを通じて開発されたオープンソース 形態素解析エンジンです。 言語, 辞書,コーパスに依存しない汎用的な設計を 基本方針としています。 パラメータの推定に Conditional Random Fields (CRF) を用 いており, ChaSenが採用している 隠れマルコフモデルに比べ性能が向上しています。また、平均的に ChaSen, Juman, KAKASIより高速に動作します。 ちなみに和布蕪(めかぶ)は, 作者の好物です。  ";
            var inputText = "全日本空輸（ANA）は3月26日 、佐賀県の協力を得て、航空業界の取り巻く環境変化に対応するため、九州佐賀国際空港をイノベーションモデル空港に位置づけ、トーイングトラクター自動走行技術など新しい技術を活用した働き方改革を推進するプロジェクトを開始した。 全日本空輸（ANA）は3月26日 、佐賀県の協力を得て、航空業界の取り巻く環境変化に対応するため、九州佐賀国際空港をイノベーションモデル空港に位置づけ、トーイングトラクター自動走行技術など新しい技術を活用した働き方改革を推進するプロジェクトを開始した。佐賀空港を空港地上支援業務に関する新しい技術を「試す」実験場として位置付け、ANAグループが取り組む先進技術を1拠点に「集める」ことで、目指すべき働き方モデルを可視化する。加えて、それぞれの技術を「繋げる」ことを通じて、一連の業務工程の相互連携を図りながら、新しい働き方を検証する。新しい技術として自動走行するトーイングトラクターを導入する。自動走行技術の活用を通じて定型反復型業務であるコンテナ牽引車両の運転業務から、人の役割が解放されている状態を目指す。リモートコントロール式航空機牽引・移動機も導入する。熟練した技術を伴わず、誰でも安全、簡単に、航空機のプッシュバック業務を担える状態を目指す。手荷物自動積み付け技術によって人とロボットの役割を分担、手荷物をコンテナへ搭載する業務が安全、効率的に実現できる状態を目指す。作業負荷を軽減するロボットスーツも活用する。装着型ロボットを活用し、重量物の運搬・搭載業務の作業負荷軽減を図る。";

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
