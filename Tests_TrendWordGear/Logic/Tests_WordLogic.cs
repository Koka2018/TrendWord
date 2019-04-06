using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace WordGear.Logic.Tests
{
    [TestClass()]
    public class Tests_WordLogic
    {
        [TestMethod]
        public void 文からトークンテーブルを取得できること()
        {
            var text = "形態素解析とは、文法的な情報の注記の無い自然言語のテキストデータから、対象言語の文法や、辞書と呼ばれる単語の品詞等の情報にもとづき、形態素の列に分割し、それぞれの形態素の品詞等を判別する作業である。";

            var tbl = WordLogic.GetBasicTokenTbl(text);

            Assert.AreEqual(34, tbl.Keys.Count);

            var key = tbl.Keys.ToArray().First();
            Assert.AreEqual("形態素解析", key);

            var word = tbl[key].First();
            Assert.AreEqual("形態素解析", word.Word);
            Assert.AreEqual("名詞,一般+サ変接続,*,*,*,*,形態素解析,ケイタイソカイセキ,ケイタイソカイセキ", word.Feature);

            Assert.AreEqual("名詞", word.Type);
            Assert.AreEqual("一般+サ変接続", word.DetailType1);
            Assert.AreEqual("*", word.DetailType2);
            Assert.AreEqual("*", word.DetailType3);
            Assert.AreEqual("*", word.AdaptMethod);
            Assert.AreEqual("*", word.AdaptType);
            Assert.AreEqual("形態素解析", word.BasicWord);
            Assert.AreEqual("ケイタイソカイセキ", word.WayOfRead);
            Assert.AreEqual("ケイタイソカイセキ", word.Pronunciation);

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
            var text = "形態素解析とは、文法的な情報の注記の無い自然言語のテキストデータから、対象言語の文法や、辞書と呼ばれる単語の品詞等の情報にもとづき、形態素の列に分割し、それぞれの形態素の品詞等を判別する作業である。";

            var tokenList = WordLogic.GetTokenList(text);

            Assert.AreEqual(53, tokenList.Count);


            var token = tokenList.First();
            Assert.AreEqual("形態素解析", token.Word);
            Assert.AreEqual("名詞,一般+サ変接続,*,*,*,*,形態素解析,ケイタイソカイセキ,ケイタイソカイセキ", token.Feature);

            Assert.AreEqual("名詞", token.Type);
            Assert.AreEqual("一般+サ変接続", token.DetailType1);
            Assert.AreEqual("*", token.DetailType2);
            Assert.AreEqual("*", token.DetailType3);
            Assert.AreEqual("*", token.AdaptMethod);
            Assert.AreEqual("*", token.AdaptType);
            Assert.AreEqual("形態素解析", token.BasicWord);
            Assert.AreEqual("ケイタイソカイセキ", token.WayOfRead);
            Assert.AreEqual("ケイタイソカイセキ", token.Pronunciation);

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
            var text = "形態素解析とは、文法的な情報の注記の無い自然言語のテキストデータから、対象言語の文法や、辞書と呼ばれる単語の品詞等の情報にもとづき、形態素の列に分割し、それぞれの形態素の品詞等を判別する作業である。";
            var tokenList = WordLogic.GetTokenList(text);
            var tokenTypeTbl = WordLogic.GetTokenTypeTbl(tokenList);

            Assert.AreEqual(7, tokenTypeTbl.Keys.Count);
            Assert.IsTrue(tokenTypeTbl.ContainsKey("名詞"));
            Assert.IsTrue(tokenTypeTbl.ContainsKey("動詞"));
            Assert.IsTrue(tokenTypeTbl.ContainsKey("助動詞"));
            Assert.IsTrue(tokenTypeTbl.ContainsKey("助詞"));
            Assert.IsTrue(tokenTypeTbl.ContainsKey("形容詞"));
            Assert.IsTrue(tokenTypeTbl.ContainsKey("記号"));
            Assert.IsTrue(tokenTypeTbl.ContainsKey("BOS/EOS"));
        }
    }
}