using Moq;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W6TW4A_HFT_2023241.Logic.LogicModels;
using W6TW4A_HFT_2023241.Models;
using W6TW4A_HFT_2023241.Repository.Interfaces;

namespace W6TW4A_HFT_2023241.Test
{
    [TestFixture]
    internal class AdventurerLogicTester
    {
        AdventurerLogic logic;
        Mock<IRepository<Adventurer>> mockAdventurerRepo;

        [SetUp]
        public void Init()
        {
            mockAdventurerRepo = new Mock<IRepository<Adventurer>>();
            mockAdventurerRepo.Setup(m=> m.ReadAll()).Returns(new List<Adventurer>()
            {
                new Adventurer("1/2/Garrick Stoneforge/Hallowed Guardians/E3/Ironhold Stronghold"),
                new Adventurer("2/2/Sylas Emberbane/Hallowed Guardians/D1/Emberfall Keep"),
                new Adventurer("3/1/Roderick Shadowblade/Nightfall Rogues/F4/Shadow's Edge"),
            }.AsQueryable());
            logic = new AdventurerLogic(mockAdventurerRepo.Object);
        }


        [Test]
        public void IsAvailableExceptionTest()
        {
            //Setup
            var adventurer=logic.ReadAll().First();
            //Act
            //Assert
            Assert.That(() => logic.IsAvailable(adventurer.AdventurerId), Throws.Nothing);
        }

        [Test]
        public void AllAvailableAdventurersInLocationExceptionTest()
        {
            //Setup
            //Act
            //Assert
            Assert.That(() => logic.AllAvailableAdventurersInLocation(null), Throws.ArgumentNullException);
        }

        [Test]
        public void CreateAdventurerTest()
        {
            var adventurer = new Adventurer("4/3/Bob/Black Hand/C4/Shadow's Edge");
            try
            {
                logic.Create(adventurer);
            }
            catch
            {
            }
            mockAdventurerRepo.Verify(r => r.Create(adventurer), Times.Once);
        }
    }

}
