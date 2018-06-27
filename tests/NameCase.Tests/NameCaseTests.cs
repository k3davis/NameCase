using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NameCase.Tests
{
    [TestClass]
    public class NameCaseTests
    {
        [TestMethod]
        public void HandlesBasicUpperNames()
        {
            const string name = "JOHN SMITH";
            Assert.AreEqual("John Smith", name.ToNameCase());
        }

        [TestMethod]
        public void HandlesBasicLowerNames()
        {
            const string name = "anne gables";
            Assert.AreEqual("Anne Gables", name.ToNameCase());
        }

        [TestMethod]
        public void HandlesLastCommaFirst()
        {
            const string name = "SMITH, JOHN";
            Assert.AreEqual("Smith, John", name.ToNameCase());
        }

        [TestMethod]
        public void HandlesSecondCapNames()
        {
            const string name = "JOHN O'MALLEY";
            Assert.AreEqual("John O'Malley", name.ToNameCase());
        }

        [TestMethod]
        public void HandlesThirdCapNames()
        {
            const string name = "RON MCDONALD";
            Assert.AreEqual("Ron McDonald", name.ToNameCase());
        }

        [TestMethod]
        public void HandlesCommonMacNames()
        {
            const string name = "JOHN MACAULIFFE";
            Assert.AreEqual("John MacAuliffe", name.ToNameCase());
        }

        [TestMethod]
        public void HandlesPiousNames()
        {
            const string name = "JOHN ST. JAMES";
            Assert.AreEqual("John St. James", name.ToNameCase());
        }

        [TestMethod]
        public void HandlesOrdinalSuffixes()
        {
            const string name = "HENRY viii";
            Assert.AreEqual("Henry VIII", name.ToNameCase());
        }

        [TestMethod]
        public void HandlesUtf8Names()
        {
            const string name = "EIÐUR SMÁRI GUÐJOHNSEN";
            Assert.AreEqual("Eiður Smári Guðjohnsen", name.ToNameCase());
        }

        [TestMethod]
        public void HandlesHyphenatedNames()
        {
            const string name = "AMY ATKINSON-LLOYD";
            Assert.AreEqual("Amy Atkinson-Lloyd", name.ToNameCase());
        }

        [TestMethod]
        public void HandlesSingleLetterNames()
        {
            const string name = "J.K. ROWLING";
            Assert.AreEqual("J.K. Rowling", name.ToNameCase());
        }

        [TestMethod]
        public void HandlesInitialLowerSurnames()
        {
            const string name = "OSCAR DE LA HOYA";
            Assert.AreEqual("Oscar de la Hoya", name.ToNameCase());
        }

        [TestMethod]
        public void HandlesSpacingDefects()
        {
            const string name = "   JOHN   SMITH ";
            Assert.AreEqual("John Smith", name.ToNameCase());
        }
    }
}