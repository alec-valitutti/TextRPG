using System;
using NUnit.Framework;
using TextRPG;
using Moq;
using TextRPG.Utilities;
using System.Collections.Generic;
using TextRPG.Items;
using TextRPG.Interfaces;
using System.IO;

namespace TextRPG.UnitTests
{
    [TestFixture]
    public class UtilityTests
    {
        internal Utility sut;
        [SetUp]
        public void Setup()
        {
            sut = new Utility();
        }

        #region CheckInput
        [Test]
        public void CheckInput_Given_Valid_Input_Executes_Logic_Returns_True()
        {
            sut.Options.Add("TestOption");
            bool result = sut.CheckInput("1", new Player());
            Assert.IsTrue(result);
        }
        [Test]
        public void CheckInput_Given_Null_String_Throws_Exception()
        {
            Assert.IsFalse(sut.CheckInput(null, new Player()));
        }
        [Test]
        public void CheckInput_Given_Empty_String_Throws_Exception()
        {
            Assert.IsFalse(sut.CheckInput("", new Player()));
        }
        [Test]
        public void CheckInput_Given_String_Not_In_Options_Throws_Exception()
        {
            Assert.IsFalse(sut.CheckInput("pizza", new Player()));
        }
        [Test]
        public void CheckInput_Given_Space_String_Throws_Exception()
        {
            Assert.IsFalse(sut.CheckInput(" ", new Player()));
        }
        #endregion
        #region CheckConditional
        [TestCase("1", true)]
        [TestCase("2", false)]
        public void CheckConditional_Given_Valid_Input_Returns_Valid_Response(string input, bool expected)
        {
            sut.Options.Add("Yes");
            sut.Options.Add("No");
            var result = sut.CheckConditional(input, new Player());
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void CheckConditional_Given_Null_String_Returns_False()
        {
            Assert.IsFalse(sut.CheckConditional(null, new Player()));
        }
        [Test]
        public void CheckConditional_Given_Empty_String_Returns_False()
        {
            Assert.IsFalse(sut.CheckConditional("", new Player()));
        }
        [Test]
        public void CheckConditional_Given_String_Not_In_Options_Returns_False()
        {
            Assert.IsFalse(sut.CheckConditional("pizza", new Player()));
        }
        [Test]
        public void CheckConditional_Given_Space_String_Returns_False()
        {
            Assert.IsFalse(sut.CheckConditional(" ", new Player()));
        }
        #endregion
        #region PrintInputOptions
        [Test]
        public void PrintInputOptions_If_Options_Not_Empty_PrintsOptions()
        {
            try
            {
                sut.PrintInputOptions(new List<string> { "hello", "goodbye" });
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not print out options", e);
                Assert.Fail();
            }
            Assert.Pass();
        }
        [Test]
        public void PrintInputOptions_Options_Empty_ThrowsException()
        {
            Assert.Throws<Exception>(() => sut.PrintInputOptions(new List<string>()));
        }
        [Test]
        public void PrintInputOptions_Options_Null_ThrowsException()
        {
            sut.Options = null;
            Assert.Throws<Exception>(() => sut.PrintInputOptions(null));
        }
        #endregion
        #region Quit
        [Test]
        public void Quit_If_Plyer_Is_Null_Throw_Exception()
        {
            Assert.Throws<Exception>(() => sut.Quit(null));
        }
        #endregion
        #region IsValidInput
        //IsValidString
        [TestCase("Pizza")]
        public void IsValidString_Given_Valid_String_Returns_True(string input)
        {
            bool result = sut.IsValidString(input, out string stringResult);
            Assert.AreEqual(stringResult, input);
            Assert.IsTrue(result);
        }
        [TestCase(null)]
        [TestCase("")]
        public void IsValidString_Given_Invalid_String_Returns_True(string input)
        {
            bool result = sut.IsValidString(input, out string stringResult);
            Assert.IsFalse(result);
        }
        #endregion
        #region GetInput
        //This has a while loop and within it, we take in user input. Need to find out how to pass in parameters
        #endregion
        #region GetConditional
        //This takes in user input. Need to find out how to pass in parameters
        [Test]
        public void GetConditionals()
        {
            TestClass testClass = new TestClass();
            using (var sw = new StringWriter())
            {
                using (var sr = new StringReader("1"))
                {
                    Console.SetIn(sr);
                    Console.SetOut(sw);
                    sut.Options.Add("Yes");
                    sut.Options.Add("No");

                    var result = sut.GetConditional(new Player());

                    Assert.IsTrue(result);
                }
            }
        }
        #endregion
        #region LoadPlayer
        [Test]
        public void LoadPlayer_LoadsPlayer()
        {
            var result = sut.LoadPlayer();
            Assert.IsInstanceOf(typeof(Player), result);
        }
        #endregion
        #region SaveObject
        [Test]
        public void SaveObject_Saves_When_Given_Object()
        {
            TestClass testClass = new TestClass() { Name = "Example" };
            try
            {
                sut.SaveObject(testClass);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
                Assert.Pass();
        }
        #endregion
        #region TextColorChanger
        //we reset the font colors on end so this isnt excatly testable
        public void TextColorChanger_Changes_Color_Based_On_Item_Rarity()
        {

        }
        #endregion
    }
    public class TestClass: IUserInput
    {
        public string Name { get; set; }

        public bool GetConditional(Player player)
        {
            return true;
        }
        public bool GetInput(Player player)
        {
            return true;
        }
    }
}
