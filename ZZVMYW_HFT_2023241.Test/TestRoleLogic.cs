using Moq;
using NUnit.Framework;
using System;
using ZZVMYW_HFT_2023241.Logic;
using ZZVMYW_HFT_2023241.Models;
using ZZVMYW_HFT_2023241.Repository;

namespace ZZVMYW_HFT_2023241.Test
{

    [TestFixture]
    public class TestRoleLogic
    {
        [Test]
        public void Create_ValidRole()
        {
            // Arrange
            var mockRepo = new Mock<IRepository<Role>>();
            var roleLogic = new RoleLogic(mockRepo.Object);
            var validRole = new Role { RoleName = "Kiss Edmund Emánuel" };

            // Act
            roleLogic.Create(validRole);

            // Assert
            mockRepo.Verify(r => r.Create(validRole), Times.Once);
        }
        [Test]
        public void Create_InvalidRoleName_ThrowsException()
        {
            // Arrange
            var mockRoleRepo = new Mock<IRepository<Role>>();
            var roleLogic = new RoleLogic(mockRoleRepo.Object);
            var invalidRole = new Role { RoleName = "abcd" };

            // Act and Assert
            Assert.Throws<Exception>(() => roleLogic.Create(invalidRole));
        }
        [Test]
        public void Create_nullRoleName_ThrowsException()
        {
            // Arrange
            var mockRoleRepo = new Mock<IRepository<Role>>();
            var roleLogic = new RoleLogic(mockRoleRepo.Object);
            var nullRole = new Role { RoleName = "" };

            // Act and Assert
            Assert.Throws<Exception>(() => roleLogic.Create(nullRole));
        }
    }
}
