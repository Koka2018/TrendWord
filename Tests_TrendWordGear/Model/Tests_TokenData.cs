using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WordGear.Model.Tests
{
    [TestClass()]
    public class Tests_TokenData
    {
        [TestMethod()]
        public void インスタンスできること_1()
        {
            string testSurface = "Surface";
            string testFeature = "品詞,品詞細分類1,品詞細分類2,品詞細分類3,活用形,活用型,原形,読み,発音";
            var token = new TokenData(testSurface, testFeature);

            Assert.IsNotNull(token);

            Assert.AreEqual(testSurface, token.Word);
            Assert.AreEqual(testFeature, token.Feature);

            Assert.AreEqual("品詞", token.Type);
            Assert.AreEqual("品詞細分類1", token.DetailType1);
            Assert.AreEqual("品詞細分類2", token.DetailType2);
            Assert.AreEqual("品詞細分類3", token.DetailType3);
            Assert.AreEqual("活用形", token.AdaptMethod);
            Assert.AreEqual("活用型", token.AdaptType);
            Assert.AreEqual("原形", token.BasicWord);
            Assert.AreEqual("読み", token.WayOfRead);
            Assert.AreEqual("発音", token.Pronunciation);
        }

        [TestMethod()]
        public void インスタンスできること_2()
        {
            var token = new TokenData("", "");

            Assert.IsNotNull(token);

            Assert.AreEqual(string.Empty, token.Word);
            Assert.AreEqual(string.Empty, token.Feature);

            Assert.AreEqual(string.Empty, token.Type);
            Assert.AreEqual(string.Empty, token.DetailType1);
            Assert.AreEqual(string.Empty, token.DetailType2);
            Assert.AreEqual(string.Empty, token.DetailType3);
            Assert.AreEqual(string.Empty, token.AdaptMethod);
            Assert.AreEqual(string.Empty, token.AdaptType);
            Assert.AreEqual(string.Empty, token.BasicWord);
            Assert.AreEqual(string.Empty, token.WayOfRead);
            Assert.AreEqual(string.Empty, token.Pronunciation);
        }
    }
}