using Moq;
using NUnit.Framework;
using System;
using ZZVMYW_HFT_2023241.Logic;
using ZZVMYW_HFT_2023241.Models;
using ZZVMYW_HFT_2023241.Repository;

namespace ZZVMYW_HFT_2023241.Test
{
    [TestFixture]
    public class TestPlayerLogic
    {
        [Test]
        public void Create_ValidPlayer_Playerlogic()
        {
            // Arrange
            var mockRepo = new Mock<IRepository<Player>>();
            var playerLogic = new PlayerLogic(mockRepo.Object);
            var validPlayer = new Player { PlayerName = "Peter Gabor Jácint" };

            // Act
            playerLogic.Create(validPlayer);

            // Assert
            mockRepo.Verify(r => r.Create(validPlayer), Times.Once);
        }
        [Test]
        public void Create_InvalidPlayerName_ThrowsException()
        {
            // Arrange
            var mockRoleRepo = new Mock<IRepository<Player>>();
            var playerLogic = new PlayerLogic(mockRoleRepo.Object);
            var invalidPlayer = new Player { PlayerName = "abcd" };

            // Act and Assert
            Assert.Throws<Exception>(() => playerLogic.Create(invalidPlayer));
        }
        [Test]
        public void Create_NullPlayerName_ThrowsException()
        {
            // Arrange
            var mockRoleRepo = new Mock<IRepository<Player>>();
            var playerLogic = new PlayerLogic(mockRoleRepo.Object);
            var nullPlayer = new Player { PlayerName = "" };

            // Act and Assert
            Assert.Throws<Exception>(() => playerLogic.Create(nullPlayer));
        }

    }
}
