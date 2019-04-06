using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WordGear.Logic.Tests
{
    [TestClass()]
    public class Tests_ParagraphLogic
    {
        [TestMethod()]
        public void 文章から文を抽出できること()
        {
            var text = "英語の文は日本語とは異なり、予め単語と単語の区切りがほとんどの箇所で明確に示される。このため、単語分割の処理は日本語の場合ほど複雑である必要はなく、簡単なルールに基づく場合が多い。例えば「It's a gift for Mr. Smith.」という文を解析することを考える。単語分割をすると以下のようになる。";
            var sentenceList = ParagraphLogic.SplitParagraph(text);

            Assert.AreEqual(4, sentenceList.Count);
        }
    }
}