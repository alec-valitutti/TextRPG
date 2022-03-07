using System;
using NUnit.Framework;
using TextRPG;
using Moq;
using TextRPG.Utilities;

namespace TextRPG.UnitTests
{
    [TestFixture]
    public class UtilityTests
    {
        #region CheckInput
        [TestCase("1")]
        public void CheckInput_UtilityHasEmptyOptions_GivenValidInput_ThrowsException(string input)
        {
            Utility sut = new Utility();
            Assert.Throws<Exception>(() => sut.CheckInput(input, out input));
        }
        //think about using TestSource
        [TestCase("1", "1")]
        [TestCase("2", "2")]
        public void CheckInput_UtilityHasOptions_GivenValidInput_ReturnsIndex(string input, string expected)
        {
            Utility sut = new Utility();
            sut.Options.Add("option1");
            sut.Options.Add("option2");
            var result = "";
            var output = sut.CheckInput(input, out result);
            Assert.AreEqual(expected, result);
        }
        [TestCase(" 1")]
        [TestCase("^Z")]
        [TestCase("asdf")]
        [TestCase(null)]
        public void CheckInput_UtilityHasOptions_GivenInvalid_ThrowsException(string input)
        {

            Utility sut = new Utility();
            sut.Options.Add("option1");
            sut.Options.Add("option2");
            Assert.Throws<Exception>(() => sut.CheckInput(input, out input));
        }
        #endregion
        #region PrintInputOptions
        [Test]
        public void PrintInputOptions_If_Options_NotEmpty_PrintsOptions()
        {
            try
            {
                Utility sut = new Utility();
                sut.Options.Add("1");
                sut.PrintInputOptions();
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not print out options", e);
                Assert.Fail();
            }
            Assert.Pass();
        }
        [Test]
        public void PrintInputOptions_OptionsEmpty_ThrowsException()
        {
            Utility sut = new Utility();
            Assert.Throws<Exception>(() => sut.PrintInputOptions());
        }
        [Test]
        public void PrintInputOptions_OptionsNull_ThrowsException()
        {
            Utility sut = new Utility();
            sut.Options = null;
            Assert.Throws<Exception>(() => sut.PrintInputOptions());
        }
        #endregion
        #region Quit
        #endregion
        #region GetInput

        #endregion
    }
}
