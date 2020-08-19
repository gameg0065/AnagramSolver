using NUnit.Framework;
using AnagramSolver.BusinessLogic;
using AnagramSolver.Generic;

namespace AnagramSolver.Tests
{
    [TestFixture]
    public class GenericsTests
    {
        private AnagramGenerator anagramGenerator;
        private DictionaryManager dictionaryManager;


        [SetUp]
        public void SetUp()
        {
            dictionaryManager = new DictionaryManager();
            anagramGenerator = new AnagramGenerator();
        }

        [TestCase()]
        public void GenericsTest()
        {
            Assert.IsTrue(MapValueToEnum<Gender, int>.Map(2) ==  Gender.Female, "Output is not - " + Gender.Female);
            Assert.IsTrue(MapValueToEnum<Gender, string>.Map("Male") == Gender.Male, "Output is not - " + Gender.Female);
            Assert.IsTrue(MapValueToEnum<Weekday, string>.Map("Sunday") == Weekday.Sunday, "Output is not - " + Gender.Female);
        }
    }
}