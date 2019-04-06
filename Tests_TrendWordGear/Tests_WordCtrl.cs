using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WordGear.Tests
{
    [TestClass()]
    public class Tests_WordCtrl
    {
        [TestMethod()]
        public void インスタンスできること()
        {
            var ctrl = new WordCtrl();

            Assert.IsNotNull(ctrl);
        }
    }
}