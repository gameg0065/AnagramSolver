using NUnit.Framework;
using AnagramSolver.BusinessLogic;

namespace AnagramSolver.Tests
{
    [TestFixture]
    public class AnagramGeneratorTests
    {
        private AnagramGenerator anagramGenerator;
        private DictionaryManager dictionaryManager;


        [SetUp]
        public void SetUp()
        {
            dictionaryManager = new DictionaryManager();
            anagramGenerator = new AnagramGenerator();
        }

        [TestCase("alus", "sula", "../../../testResources/zodynas.txt")]
        [TestCase("sula", "alus", "../../../testResources/zodynas.txt")]
        [TestCase("labas", "balas", "../../../testResources/zodynas.txt")]
        [TestCase("pilkas", "plikas", "../../../testResources/zodynas.txt")]
        public void AnagramGeneratorTest(string input, string expectedOutput, string dictionaryPath)
        {
            // var isExpectedOutput = false;
            // dictionaryManager.LoadDictionary(dictionaryPath);
            // // var result = anagramGenerator.GenerateAnagrams(input, 1);
            // foreach (var item in result)
            // {
            //     if(item == expectedOutput) {
            //         isExpectedOutput = true;
            //     }
            // }
            // Assert.IsTrue(isExpectedOutput, "Output is not - " + expectedOutput);
        }
    }
}