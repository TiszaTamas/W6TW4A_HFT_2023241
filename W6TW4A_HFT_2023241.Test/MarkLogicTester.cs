using Microsoft.EntityFrameworkCore.Query.Internal;
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
    [TestFixture]
    internal class MarkLogicTester
    {
        MarkLogic logic;
        Mock<IRepository<Mark>> mockMarkRepo;

        [SetUp]
        public void Init()
        {
            mockMarkRepo = new Mock<IRepository<Mark>>();
            mockMarkRepo.Setup(m => m.ReadAll()).Returns(new List<Mark>()
            {
                new Mark("1/1/2"),
                new Mark("2/1/3"),
                new Mark("3/2/2"),
            }.AsQueryable());
            logic = new MarkLogic(mockMarkRepo.Object);
        }

        [Test]
        public void MonsterFinderTest()
        {
            //Setup
            //Act
            //Assert
            Assert.That(() => logic.MonsterFinder(-1), Throws.ArgumentException);

        }

        [Test]
        public void ReadMarkExceptionTest()
        {
            //Setup
            //Act
            //Assert
            Assert.That(() => logic.Read(-1), Throws.ArgumentException);

        }

        [Test]
        public void CreateMarkTest()
        {
            var Mark = new Mark("4/2/2");
            try
            {
                logic.Create(Mark);
            }
            catch
            {
            }
            mockMarkRepo.Verify(r => r.Create(Mark), Times.Once);
        }
    }
}
