using Microsoft.VisualStudio.TestTools.UnitTesting;
using XamFormsUnitTesting;

namespace UnitTestCore
{
    [TestClass]
    public class ReverseServiceTests
    {
        [TestMethod]
        public void Should_Reverse_Word()
        {
            // Arrange
            string word = "ABC";
            string reversedWord = "CBA";
            ReverseService reverseService = new ReverseService();

            // Act
            string result = reverseService.ReverseWord(word);

            // Assert
            Assert.AreEqual(result, reversedWord);
        }
    }
}
