using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Memory;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MemoryTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Boolean expected = false;
            var setupPlayer2 = new NaamInvoer2();
            bool actual = setupPlayer2.hasSameName("Josh", "Jake");

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod2()
        {
            int expected = 1;
            ImageSource source = new BitmapImage(new Uri("Images/1.png", UriKind.Relative));
            Card card = new Card(source,1);
            int actual = card.getNumber();

            Assert.AreEqual(expected, actual);
        }
    }
}
