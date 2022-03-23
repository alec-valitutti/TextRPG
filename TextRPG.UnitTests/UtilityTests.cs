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
        internal Utility Sut;
        internal Player TestPlayer;
        internal Item TestItem = new Item("ITEM", Rarity.Rare);
        [SetUp]
        public void Setup()
        {
            Sut = new Utility();
            TestPlayer = Sut.LoadPlayer();
        }
        #region PrintInputOptions
        [Test]
        public void PrintInputOptions_If_Options_Not_Empty_PrintsOptions()
        {
            var result = new List<string> { "hello", "goodbye" };
            try
            {
                Sut = new Utility();
                Sut.PrintInputOptions(result);
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
            Assert.Throws<Exception>(() => Sut.PrintInputOptions(new List<string>()));
        }
        [Test]
        public void PrintInputOptions_Options_Null_ThrowsException()
        {
            Sut.Options = null;
            Assert.Throws<Exception>(() => Sut.PrintInputOptions(null));
        }
        #endregion
        #region Quit
        [Test]
        public void Quit_If_Plyer_Is_Null_Throw_Exception()
        {
            Assert.Throws<Exception>(() => Sut.Quit(null));
        }
        #endregion
        #region IsValidString
        //IsValidString
        [TestCase("Pizza")]
        public void IsValidString_Given_Valid_String_Returns_True(string input)
        {
            bool result = Sut.IsValidString(input, out string stringResult);
            Assert.AreEqual(stringResult, input);
            Assert.IsTrue(result);
        }
        [TestCase(null)]
        [TestCase("")]
        public void IsValidString_Given_Invalid_String_Returns_True(string input)
        {
            bool result = Sut.IsValidString(input, out string stringResult);
            Assert.IsFalse(result);
        }
        #endregion
        #region GetInput
        [Test]
        public void GetInput_Handles_Input_Returns_Player()
        {
            Sut.Options.Add("Return");
            using var sw = new StringWriter();
            using var sr = new StringReader("1");
            Console.SetIn(sr);
            Console.SetOut(sw);
            var result = Sut.GetInput(TestPlayer);
            Assert.AreEqual(TestPlayer, result);
        }
        #endregion
        #region GetConditional
        [Test]
        public void GetConditionals_If_Input_Is_1_Return_true()
        {
            using (var sw = new StringWriter())
            {
                using (var sr = new StringReader("1"))
                {
                    Console.SetIn(sr);
                    Console.SetOut(sw);
                    Sut.Options.Add("Yes");
                    Sut.Options.Add("No");

                    var result = Sut.GetConditional();

                    Assert.IsTrue(result);
                }
            }
        }
        [Test]
        public void GetConditionals_If_Input_Is_2_Return_false()
        {
            using var sw = new StringWriter();
            using var sr = new StringReader("2");
            Console.SetIn(sr);
            Console.SetOut(sw);
            Sut.Options.Add("Yes");
            Sut.Options.Add("No");

            var result = Sut.GetConditional();

            Assert.IsFalse(result);
        }
        #endregion
        #region LoadPlayer
        [Test]
        public void LoadPlayer_Reads_Player_File_Creates_Player_Returns_Player_Object()
        {
            var result = Sut.LoadPlayer();
            Assert.IsInstanceOf(typeof(Player), result);
        }
        #endregion
        #region SavePlayer
        [Test]
        public void SavePlayer_Saves_When_Given_Object()
        {
            /*Would be nice to figure out how to generically save any object like i had before*/
            TestClass testClass = new TestClass() { Name = "Example" };
            try
            {
                Sut.SavePlayer(testClass);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
            Assert.Pass();
        }
        #endregion
        #region MessageEnder
        /*I may get rid of this method because I don't like that I call this to clear after certain input*/
        [Test]
        public void MessageEnder_Does_Not_Throw_Exception()
        {
            try
            {
                using var sw = new StringWriter();
                using var sr = new StringReader("2");
                Console.SetIn(sr);
                Console.SetOut(sw);
                Sut.MessageEnder();
            }
            catch (Exception)
            {
                Assert.Fail();
            }
            Assert.Pass();
        }
        #endregion
        #region TextColorChanger
        [Test]
        public void TextColorChanger_Given_Item_Does_Not_Throw_Exception()
        {
            try
            {
                Sut.TextColorChanger(TestItem);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
            Assert.Pass();
        }
        #endregion
    }
    public class TestClass : Player
    {
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
