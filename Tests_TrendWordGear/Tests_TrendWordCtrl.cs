﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace TrendWordGear.Tests
{
    [TestClass()]
    public class Tests_TrendWordCtrl
    {
        [TestMethod()]
        public void インスタンスできること()
        {
            var ctrl = new TrendWordCtrl();

            Assert.IsNotNull(ctrl);
        }

        #region 形態素解析

        [TestMethod]
        public void 文からトークンテーブルを取得できること()
        {
            var ctrl = new TrendWordCtrl();
            var text = "形態素解析とは、文法的な情報の注記の無い自然言語のテキストデータから、対象言語の文法や、辞書と呼ばれる単語の品詞等の情報にもとづき、形態素の列に分割し、それぞれの形態素の品詞等を判別する作業である。";

            var tbl = ctrl.GetBasicTokenTbl(text);

            Assert.AreEqual(37, tbl.Keys.Count);

            var key = tbl.Keys.ToArray().First();
            Assert.AreEqual("形態素", key);

            var word = tbl[key].First();
            Assert.AreEqual("形態素", word.Word);
            Assert.AreEqual("名詞,一般,*,*,*,*,形態素,ケイタイソ,ケイタイソ", word.Feature);

            Assert.AreEqual("名詞", word.Type);
            Assert.AreEqual("一般", word.DetailType1);
            Assert.AreEqual("*", word.DetailType2);
            Assert.AreEqual("*", word.DetailType3);
            Assert.AreEqual("*", word.AdaptMethod);
            Assert.AreEqual("*", word.AdaptType);
            Assert.AreEqual("形態素", word.BasicWord);
            Assert.AreEqual("ケイタイソ", word.WayOfRead);
            Assert.AreEqual("ケイタイソ", word.Pronunciation);

            key = tbl.Keys.ToArray()[tbl.Keys.ToArray().Count() - 2];
            Assert.AreEqual("。", key);

            word = tbl[key].Last();
            Assert.AreEqual("。", word.Word);
            Assert.AreEqual("記号,句点,*,*,*,*,。,。,。", word.Feature);

            Assert.AreEqual("記号", word.Type);
            Assert.AreEqual("句点", word.DetailType1);
            Assert.AreEqual("*", word.DetailType2);
            Assert.AreEqual("*", word.DetailType3);
            Assert.AreEqual("*", word.AdaptMethod);
            Assert.AreEqual("*", word.AdaptType);
            Assert.AreEqual("。", word.BasicWord);
            Assert.AreEqual("。", word.WayOfRead);
            Assert.AreEqual("。", word.Pronunciation);
        }

        [TestMethod]
        public void 文からトークンリストを取得できること()
        {
            var ctrl = new TrendWordCtrl();
            var text = "形態素解析とは、文法的な情報の注記の無い自然言語のテキストデータから、対象言語の文法や、辞書と呼ばれる単語の品詞等の情報にもとづき、形態素の列に分割し、それぞれの形態素の品詞等を判別する作業である。";

            var tokenList = ctrl.GetTokenList(text);

            Assert.AreEqual(60, tokenList.Count);


            var token = tokenList.First();
            Assert.AreEqual("形態素", token.Word);
            Assert.AreEqual("名詞,一般,*,*,*,*,形態素,ケイタイソ,ケイタイソ", token.Feature);

            Assert.AreEqual("名詞", token.Type);
            Assert.AreEqual("一般", token.DetailType1);
            Assert.AreEqual("*", token.DetailType2);
            Assert.AreEqual("*", token.DetailType3);
            Assert.AreEqual("*", token.AdaptMethod);
            Assert.AreEqual("*", token.AdaptType);
            Assert.AreEqual("形態素", token.BasicWord);
            Assert.AreEqual("ケイタイソ", token.WayOfRead);
            Assert.AreEqual("ケイタイソ", token.Pronunciation);

            token = tokenList[tokenList.Count - 2];
            Assert.AreEqual("。", token.Word);
            Assert.AreEqual("記号,句点,*,*,*,*,。,。,。", token.Feature);

            Assert.AreEqual("記号", token.Type);
            Assert.AreEqual("句点", token.DetailType1);
            Assert.AreEqual("*", token.DetailType2);
            Assert.AreEqual("*", token.DetailType3);
            Assert.AreEqual("*", token.AdaptMethod);
            Assert.AreEqual("*", token.AdaptType);
            Assert.AreEqual("。", token.BasicWord);
            Assert.AreEqual("。", token.WayOfRead);
            Assert.AreEqual("。", token.Pronunciation);
        }

        [TestMethod]
        public void トークンリストの品詞分類ができること()
        {
            var ctrl = new TrendWordCtrl();
            var text = "形態素解析とは、文法的な情報の注記の無い自然言語のテキストデータから、対象言語の文法や、辞書と呼ばれる単語の品詞等の情報にもとづき、形態素の列に分割し、それぞれの形態素の品詞等を判別する作業である。";
            var tokenList = ctrl.GetTokenList(text);
            var tokenTypeTbl = ctrl.GetTokenTypeTbl(tokenList);

            Assert.AreEqual(7, tokenTypeTbl.Keys.Count);
            Assert.IsTrue(tokenTypeTbl.ContainsKey("名詞"));
            Assert.IsTrue(tokenTypeTbl.ContainsKey("動詞"));
            Assert.IsTrue(tokenTypeTbl.ContainsKey("助動詞"));
            Assert.IsTrue(tokenTypeTbl.ContainsKey("助詞"));
            Assert.IsTrue(tokenTypeTbl.ContainsKey("形容詞"));
            Assert.IsTrue(tokenTypeTbl.ContainsKey("記号"));
            Assert.IsTrue(tokenTypeTbl.ContainsKey("BOS/EOS"));
        }

        #endregion

        #region 集計メソッド

        [DataTestMethod]
        [DataRow("名詞", 27)]
        [DataRow("動詞", 5)]
        [DataRow("助動詞", 3)]
        [DataRow("助詞", 17)]
        [DataRow("形容詞", 1)]
        [DataRow("記号", 6)]
        [DataRow("BOS/EOS", 1)]
        [DataRow("副詞", 0)]
        public void 品詞を限定したトークンリストを取得できること(string testData_type, int testData_tokenNum)
        {
            var ctrl = new TrendWordCtrl();
            var text = "形態素解析とは、文法的な情報の注記の無い自然言語のテキストデータから、対象言語の文法や、辞書と呼ばれる単語の品詞等の情報にもとづき、形態素の列に分割し、それぞれの形態素の品詞等を判別する作業である。";
            var tokenList = ctrl.GetTokenList(text);
            var extractedTokenList = ctrl.ExtractTokenType(tokenList, testData_type);

            Assert.AreEqual(testData_tokenNum, extractedTokenList.Count);
            foreach(var token in extractedTokenList)
            {
                Assert.AreEqual(testData_type, token.Type);
            }
        }

        [DataTestMethod]
        [DataRow("名詞", 20)]
        [DataRow("動詞", 4)]
        [DataRow("助動詞", 2)]
        [DataRow("助詞", 7)]
        [DataRow("形容詞", 1)]
        [DataRow("記号", 2)]
        [DataRow("BOS/EOS", 1)]
        [DataRow("副詞", 0)]
        public void 品詞を限定したトークンテーブルを取得できること(string testData_type, int testData_tokenNum)
        {
            var ctrl = new TrendWordCtrl();
            var text = "形態素解析とは、文法的な情報の注記の無い自然言語のテキストデータから、対象言語の文法や、辞書と呼ばれる単語の品詞等の情報にもとづき、形態素の列に分割し、それぞれの形態素の品詞等を判別する作業である。";
            var tokenTbl = ctrl.GetBasicTokenTbl(text);
            var extractedTokenTbl = ctrl.ExtractTokenType(tokenTbl, testData_type);

            Assert.AreEqual(testData_tokenNum, extractedTokenTbl.Keys.Count);
            foreach(var subTokenList in extractedTokenTbl.Values)
            {
                foreach (var token in subTokenList)
                {
                    Assert.AreEqual(testData_type, token.Type);
                }
            }
        }

        #endregion
    }
}