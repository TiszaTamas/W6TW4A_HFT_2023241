using Moq;
using NUnit.Framework;
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
    internal class QuestLogicTester
    {
        QuestLogic logic;
        Mock<IRepository<Quest>> mockQuestRepo;

        [SetUp]
        public void Init()
        {
            mockQuestRepo = new Mock<IRepository<Quest>>();
            mockQuestRepo.Setup(m => m.ReadAll()).Returns(new List<Quest>()
            {
                new Quest("1/Rescue the Lost Scholar/E4/Arcane Academy/Ancient tome of magical knowledge",true),
                new Quest("2/Herb Gathering Expedition/D2/Herbalist Guild/Pouch of gold and rare potion ingredients",false),
                new Quest("3/Locate the Missing Explorer/D3/Explorers' Guild/Unique map revealing hidden locations",true),

            }.AsQueryable());
            logic = new QuestLogic(mockQuestRepo.Object);
        }

        [Test]
        public void HighestAdventurerOnQuestExceptionTest()
        {
            //Setup
            //Act
            //Assert
            Assert.That(() => logic.HighestAdventurerOnQuest(-1), Throws.ArgumentException);

        }

        [Test]
        public void ReadQuestExceptionTest()
        {
            //Setup
            //Act
            //Assert
            Assert.That(() => logic.Read(-1), Throws.ArgumentException);

        }

        [Test]
        public void CreateQuestTest()
        {
            var quest = new Quest("4/Locate someone somwhere/D3/Explorers' Guild/Unique map revealing hidden locations",false);
            try
            {
                logic.Create(quest);
            }
            catch
            {
            }
            mockQuestRepo.Verify(r => r.Create(quest), Times.Once);
        }
    }
}
