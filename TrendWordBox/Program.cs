﻿using System;
using TrendWordGear;

namespace TrendWordBox
{
    class Program
    {
        static void Main(string[] args)
        {
            var ctrl = new TrendWordCtrl();

            var tbl = ctrl.GetTokenTbl("MeCabは 京都大学情報学研究科−日本電信電話株式会社コミュニケーション科学基礎研究所 共同研究ユニットプロジェクトを通じて開発されたオープンソース 形態素解析エンジンです。 言語, 辞書,コーパスに依存しない汎用的な設計を 基本方針としています。 パラメータの推定に Conditional Random Fields (CRF) を用 いており, ChaSenが採用している 隠れマルコフモデルに比べ性能が向上しています。また、平均的に ChaSen, Juman, KAKASIより高速に動作します。 ちなみに和布蕪(めかぶ)は, 作者の好物です。  ");

            foreach(var basicWord in tbl.Keys)
            {
                Console.WriteLine(basicWord + "\t" + tbl[basicWord].Count);
            }

            Console.ReadLine();
        }
    }
}