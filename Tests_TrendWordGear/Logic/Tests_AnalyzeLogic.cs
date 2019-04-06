using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WordGear.Logic.Tests
{
    [TestClass()]
    public class Tests_AnalyzeLogic
    {
        [DataTestMethod]
        [DataRow("名詞", 17)]
        [DataRow("動詞", 4)]
        [DataRow("助動詞", 2)]
        [DataRow("助詞", 7)]
        [DataRow("形容詞", 1)]
        [DataRow("記号", 2)]
        [DataRow("BOS/EOS", 1)]
        [DataRow("副詞", 0)]
        public void 品詞を限定したトークンテーブルを取得できること(string testData_type, int testData_tokenNum)
        {
            var text = "形態素解析とは、文法的な情報の注記の無い自然言語のテキストデータから、対象言語の文法や、辞書と呼ばれる単語の品詞等の情報にもとづき、形態素の列に分割し、それぞれの形態素の品詞等を判別する作業である。";
            var tokenTbl = WordLogic.GetBasicTokenTbl(text);
            var extractedTokenTbl = AnalyzeLogic.ExtractTokenType(tokenTbl, testData_type);

            Assert.AreEqual(testData_tokenNum, extractedTokenTbl.Keys.Count);
            foreach (var subTokenList in extractedTokenTbl.Values)
            {
                foreach (var token in subTokenList)
                {
                    Assert.AreEqual(testData_type, token.Type);
                }
            }
        }

        [DataTestMethod]
        [DataRow("名詞", 20)]
        [DataRow("動詞", 5)]
        [DataRow("助動詞", 3)]
        [DataRow("助詞", 17)]
        [DataRow("形容詞", 1)]
        [DataRow("記号", 6)]
        [DataRow("BOS/EOS", 1)]
        [DataRow("副詞", 0)]
        public void 品詞を限定したトークンリストを取得できること(string testData_type, int testData_tokenNum)
        {
            var text = "形態素解析とは、文法的な情報の注記の無い自然言語のテキストデータから、対象言語の文法や、辞書と呼ばれる単語の品詞等の情報にもとづき、形態素の列に分割し、それぞれの形態素の品詞等を判別する作業である。";
            var tokenList = WordLogic.GetTokenList(text);
            var extractedTokenList = AnalyzeLogic.ExtractTokenType(tokenList, testData_type);

            Assert.AreEqual(testData_tokenNum, extractedTokenList.Count);
            foreach (var token in extractedTokenList)
            {
                Assert.AreEqual(testData_type, token.Type);
            }
        }
    }
}