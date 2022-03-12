using System;
using NUnit.Framework;
using TextRPG;
using Moq;
using TextRPG.Utilities;
using System.Collections.Generic;
using TextRPG.Items;

namespace TextRPG.UnitTests
{
    [TestFixture]
    public class UtilityTests
    {

        #region CheckInput
        [Test]
        public void CheckInput_Given_Valid_Input_Executes_Logic_Returns_True()
        {
            Utility utility = new Utility();
            utility.Options.Add("TestOption");
            bool result = utility.CheckInput("1", new Player());
            Assert.IsTrue(result);
        }
        [Test]
        public void CheckInput_Given_Null_String_Throws_Exception()
        {
            Utility utility = new Utility();
            Assert.IsFalse(utility.CheckInput(null, new Player()));
        }
        [Test]
        public void CheckInput_Given_Empty_String_Throws_Exception()
        {
            Utility utility = new Utility();
            Assert.IsFalse(utility.CheckInput("", new Player()));
        }
        [Test]
        public void CheckInput_Given_String_Not_In_Options_Throws_Exception()
        {
            Utility utility = new Utility();
            Assert.IsFalse(utility.CheckInput("pizza", new Player()));
        }
        [Test]
        public void CheckInput_Given_Space_String_Throws_Exception()
        {
            Utility utility = new Utility();
            Assert.IsFalse(utility.CheckInput(" ", new Player()));
        }
        #endregion
        #region CheckConditional
        [TestCase("1", true)]
        [TestCase("2", false)]
        public void CheckConditional_Given_Valid_Input_Returns_Valid_Response(string input, bool expected)
        {
            Utility utility = new Utility();
            utility.Options.Add("Yes");
            utility.Options.Add("No");
            var result = utility.CheckConditional(input, new Player());
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void CheckConditional_Given_Null_String_Returns_False()
        {
            Utility utility = new Utility();
            Assert.IsFalse(utility.CheckConditional(null, new Player()));
        }
        [Test]
        public void CheckConditional_Given_Empty_String_Returns_False()
        {
            Utility utility = new Utility();
            Assert.IsFalse(utility.CheckConditional("", new Player()));
        }
        [Test]
        public void CheckConditional_Given_String_Not_In_Options_Returns_False()
        {
            Utility utility = new Utility();
            Assert.IsFalse(utility.CheckConditional("pizza", new Player()));
        }
        [Test]
        public void CheckConditional_Given_Space_String_Returns_False()
        {
            Utility utility = new Utility();
            Assert.IsFalse(utility.CheckConditional(" ", new Player()));
        }
        #endregion
        #region PrintInputOptions
        [Test]
        public void PrintInputOptions_If_Options_Not_Empty_PrintsOptions()
        {
            try
            {
                Utility sut = new Utility();
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
            Utility sut = new Utility();
            Assert.Throws<Exception>(() => sut.PrintInputOptions(new List<string>()));
        }
        [Test]
        public void PrintInputOptions_Options_Null_ThrowsException()
        {
            Utility sut = new Utility();
            sut.Options = null;
            Assert.Throws<Exception>(() => sut.PrintInputOptions(null));
        }
        #endregion
        #region Quit
        [Test]
        public void Quit_If_Plyer_Is_Null_Throw_Exception()
        {
            Utility utility = new Utility();
            Assert.Throws<Exception>(() => utility.Quit(null));
        }
        #endregion
        #region IsValidInput
        //IsValidString
        [TestCase("Pizza")]
        public void IsValidString_Given_Valid_String_Returns_True(string input)
        {
            Utility utility = new Utility();
            string stringResult = "";
            bool result = utility.IsValidString(input, out stringResult);
            Assert.AreEqual(stringResult, input);
            Assert.IsTrue(result);
        }
        [TestCase(null)]
        [TestCase("")]
        public void IsValidString_Given_Invalid_String_Returns_True(string input)
        {
            Utility utility = new Utility();
            string stringResult = "";
            bool result = utility.IsValidString(input, out stringResult);
            Assert.IsFalse(result);
        }
        #endregion
        #region GetInput
        //This has a while loop and within it, we take in user input. Need to find out how to pass in parameters
        #endregion
        #region GetConditional
        //This takes in user input. Need to find out how to pass in parameters
        #endregion
        #region LoadPlayer
        [Test]
        public void LoadPlayer_LoadsPlayer()
        {
            Utility utility = new Utility();
            var result = utility.LoadPlayer();
            Assert.IsInstanceOf(typeof(Player), result);
        }
        #endregion
        #region SaveObject
        [Test]
        public void SaveObject_Saves_When_Given_Object()
        {
            TestClass testClass = new TestClass() { name = "Example" };
            Utility utility = new Utility();
            try
            {
                utility.SaveObject(testClass);
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
            Utility utility = new Utility();
            utility.TextColorChanger(new List<Item>{ new Armor { Name="armor",_Rarity=Rarity.Common} });
            Assert.IsTrue(Console.ForegroundColor == ConsoleColor.DarkGray);
            utility.TextColorChanger(new List<Item>{ new Armor { Name="sword",_Rarity=Rarity.Uncommon} });
            Assert.IsTrue(Console.ForegroundColor == ConsoleColor.White);
            utility.TextColorChanger(new List<Item>{ new Armor { Name="sword",_Rarity=Rarity.Rare} });
            Assert.IsTrue(Console.ForegroundColor == ConsoleColor.Cyan);
            utility.TextColorChanger(new List<Item>{ new Armor { Name="sword",_Rarity=Rarity.Unique} });
            Assert.IsTrue(Console.ForegroundColor == ConsoleColor.Yellow);
            utility.TextColorChanger(new List<Item>{ new Armor { Name="sword",_Rarity=Rarity.Legendary} });
            Assert.IsTrue(Console.ForegroundColor == ConsoleColor.Magenta);
        }
        #endregion
    }
    public class TestClass
    {
        public string name { get; set; }
    };
}
