using Moq;
using NUnit.Framework;
using System;
using ZZVMYW_HFT_2023241.Logic;
using ZZVMYW_HFT_2023241.Models;
using ZZVMYW_HFT_2023241.Repository;

namespace ZZVMYW_HFT_2023241.Test
{
    [TestFixture]
    public class TestCoachLogic
    {

        [Test]
        public void Create_ValidCoach()
        {
            // Act
            var mockRepo = new Mock<IRepository<Coach>>();
            var coachLogic = new CoachLogic(mockRepo.Object);

            var validCoach = new Coach { CoachName = "Kiss Péter Elemér" };

            // Arrange
            coachLogic.Create(validCoach);

            // Assert
            mockRepo.Verify(r => r.Create(validCoach), Times.Once);
        }
        [Test]
        public void Create_InValidCoachThrowsExecption()
        {
            // Arrange
            var mockCoachRepo = new Mock<IRepository<Coach>>();
            var CoachLogic = new CoachLogic(mockCoachRepo.Object);
            var invalidCoach = new Coach { CoachName = "abcd" };

            // Act and Assert
            Assert.Throws<Exception>(() => CoachLogic.Create(invalidCoach));
        }
        [Test]
        public void Create_nullCoachThrowsExecption()
        {
            // Arrange
            var mockCoachRepo = new Mock<IRepository<Coach>>();
            var CoachLogic = new CoachLogic(mockCoachRepo.Object);
            var invalidCoach = new Coach { CoachName = "" };

            // Act and Assert
            Assert.Throws<Exception>(() => CoachLogic.Create(invalidCoach));
        }

        [Test]
        public void Delete_ValidIdCoach()
        {
            // Act
            var mockRepo = new Mock<IRepository<Coach>>();
            var coachLogic = new CoachLogic(mockRepo.Object);
            var validCoachId = 1;

            // Assert
            coachLogic.Delete(validCoachId);

            // Arrange
            mockRepo.Verify(r => r.Delete(validCoachId), Times.Once);
        }
    }
}
