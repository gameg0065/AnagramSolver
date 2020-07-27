using NUnit.Framework;
using AnagramSolver.BusinessLogic;

namespace Prime.UnitTests.Services
{
    [TestFixture]
    public class PrimeService_IsPrimeShould
    {
        private AnagramGenerator _primeService;

        [SetUp]
        public void SetUp()
        {
            _primeService = new AnagramGenerator();
        }

        [Test]
        public void IsPrime_InputIs1_ReturnFalse()
        {
            var result = _primeService.Test("Mantas");

            Assert.IsFalse(result, "1 should not be prime");
        }
    }
}