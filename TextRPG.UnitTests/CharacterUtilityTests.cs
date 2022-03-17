using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TextRPG.Utilities;

namespace TextRPG.UnitTests
{
    [TestFixture]
    class CharacterUtilityTests
    {
        CharacterUtility sut { get; set; }
        [SetUp]
        public void Setup()
        {
            sut = new CharacterUtility();
        }
        #region CreateCharacter
        [Test]
        public void CreateCharacter()
        {
            try
            {
                sut.CreateCharacter();
            }
            catch (Exception)
            {
                Assert.Fail();
            }
            Assert.Pass();
        }
        #endregion
        #region ChooseClass
        #endregion
        #region PrintPlayerEquipment
        #endregion
        #region PrintPlayerAbilities
        #endregion
        #region PrintPlayerStatistics
        #endregion
        #region PrintPlayerAmmunition
        #endregion
        #region PrintPlayerInventory
        #endregion
    }
}
