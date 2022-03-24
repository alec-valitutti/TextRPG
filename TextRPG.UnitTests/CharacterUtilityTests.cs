using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TextRPG.Utilities;
using TextRPG.Items;
using TextRPG.States;

namespace TextRPG.UnitTests
{
    [TestFixture]
    class CharacterUtilityTests
    {
        internal CharacterUtility Sut { get; set; }
        internal Utility Util { get; set; }
        internal Player TestPlayer { get; set; }
        internal Item TestItem { get; set; }
        internal UseItemState UseItemGameState { get; set; }
        [SetUp]
        public void Setup()
        {
            Sut = new CharacterUtility();
            Util = new Utility();
            TestItem = new Consumeable("Potion", Rarity.Rare);
            TestPlayer = Util.LoadPlayer();
            UseItemGameState = new UseItemState(TestPlayer);
        }
        #region CreateCharacter
        //[Test]
        public void CreateCharacter()
        {
            /*This is going to be a mess to unit test - needs to be rewritten*/
            try
            {
                Sut.CreateCharacter();
            }
            catch (Exception)
            {
                Assert.Fail();
            }
            Assert.Pass();
        }
        #endregion
        #region ChooseClass
        [TestCase("1", "Warrior")]
        [TestCase("2", "Mage")]
        [TestCase("3", "Archer")]
        public void ChooseClass_Sets_Class_To_Selected_Class(string input, string expected)
        {
            using var sw = new StringWriter();
            using var sr = new StringReader(input);
            Console.SetIn(sr);
            Console.SetOut(sw);
            var result = Sut.ChooseClass(TestPlayer);
            Assert.IsTrue(result._PlayerClass == expected);
        }
        #endregion
        #region PrintPlayerEquipment
        [Test]
        public void PrintPlayerEquipment_When_Called_Doesnt_Throw_Exception()
        {
            try
            {
                Sut.PrintPlayerEquipment(TestPlayer);
            }
            catch (Exception)
            {

                Assert.Fail();
            }
            Assert.Pass();
        }
        #endregion
        #region PrintPlayerAbilities
        [Test]
        public void PrintPlayerAbilities_When_Called_Doesnt_Throw_Exception()
        {
            try
            {
                Sut.PrintPlayerAbilities(TestPlayer);
            }
            catch (Exception)
            {

                Assert.Fail();
            }
            Assert.Pass();
        }
        #endregion
        #region PrintPlayerStatistics
        [Test]
        public void PrintStatistics_When_Called_Doesnt_Throw_Exception()
        {
            try
            {
                Sut.PrintPlayerStatistics(TestPlayer);
            }
            catch (Exception)
            {

                Assert.Fail();
            }
            Assert.Pass();
        }
        #endregion
        #region PrintPlayerAmmunition
        [Test]
        public void PrintPlayerAmmunition_When_Called_Doesnt_Throw_Exception()
        {
            try
            {
                Sut.PrintPlayerAmmunition(TestPlayer);
            }
            catch (Exception)
            {

                Assert.Fail();
            }
            Assert.Pass();
        }
        #endregion
        #region PrintPlayerAttributes
        [Test]
        public void PrintPlayerAttributes_When_Called_Doesnt_Throw_Exception()
        {
            try
            {
                Sut.PrintPlayerAttributes(TestPlayer);
            }
            catch (Exception)
            {

                Assert.Fail();
            }
            Assert.Pass();
        }
        #endregion
        #region PrintPlayerInventory
        [Test]
        public void PrintPlayerInventory_When_Called_Doesnt_Throw_Exception()
        {
            try
            {
                Sut.PrintPlayerInventory(TestPlayer);
            }
            catch (Exception)
            {

                Assert.Fail();
            }
            Assert.Pass();
        }
        #endregion
        #region PrintPlayerGold
        [Test]
        public void PrintPlayerGold_When_Called_Doesnt_Throw_Exception()
        {
            try
            {
                Sut.PrintPlayerGold(TestPlayer);
            }
            catch (Exception)
            {

                Assert.Fail();
            }
            Assert.Pass();
        }
        #endregion
        #region GetInputForItemUse
        [Test]
        public void GetInputForItemUse_Gets_Input_Uses_Item_Removes_Item_From_Inventory()
        {
            using var sw = new StringWriter();
            using var sr = new StringReader("1");
            Console.SetIn(sr);
            Console.SetOut(sw);
            TestPlayer.Inventory.Add(TestItem);
            Sut.Options.AddRange(UseItemGameState.AddOptions());
            var result = Sut.GetInput(TestPlayer);
            Assert.IsTrue(!result.Inventory.Contains(TestItem));
        }
        #endregion
    }
}
