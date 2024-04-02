using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using ZZVMYW_HFT_2023241.Logic;
using ZZVMYW_HFT_2023241.Models;
using ZZVMYW_HFT_2023241.Repository;

namespace ZZVMYW_HFT_2023241.Test
{

    [TestFixture]
    public class TestTeamLogic
    {
        [Test] 
        public void Delete_ValidIdTeam()
        {
            //Act
            var mockRepo = new Mock<IRepository<Team>>();
            var teamLogic = new TeamLogic(mockRepo.Object);
            var validTeamId = 1;

            // Assert
            teamLogic.Delete(validTeamId);

            // Arrange
            mockRepo.Verify(r => r.Delete(validTeamId), Times.Once);
        }


        //NONCRUD methods

        [Test]
        public void Test_getAvgPlayersAge_By_TeamId()
        {
            TeamLogic teamLogic;
            Mock<IRepository<Team>> mockRepoTeam;
            mockRepoTeam = new Mock<IRepository<Team>>();
            teamLogic = new TeamLogic(mockRepoTeam.Object);
            // Arrange
            int existingTeamId = 1;

            // Mock setup
            mockRepoTeam.Setup(repo => repo.ReadAll()).Returns(new List<Team>
        {
            new Team { TeamId = existingTeamId, Players = new List<Player> { new Player { Age = 25 }, new Player { Age = 30 } } }
        }.AsQueryable());

            // Act
            double? result = teamLogic.getAvgPlayersAgeByTeamId(existingTeamId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(27.5, result.Value);

        }

        [Test]
        public void Test_getTheOldestPlayer_By_TeamIdValid()
        {
            TeamLogic teamLogic;
            Mock<IRepository<Team>> mockRepoTeam;
            mockRepoTeam = new Mock<IRepository<Team>>();
            teamLogic = new TeamLogic(mockRepoTeam.Object);

            // Arrange
            int existingTeamId = 1;

            // Mock setup
            mockRepoTeam.Setup(repo => repo.ReadAll()).Returns(new List<Team>
        {
            new Team
            {
                TeamId = existingTeamId,
                Players = new List<Player>
                {
                    new Player { PlayerName = "Player1", Age = 25 },
                    new Player { PlayerName = "Player2", Age = 30 }
                }
            }
        }.AsQueryable());

            // Act
            string result = teamLogic.getTheOldestPlayerByTeamId(existingTeamId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Player2", result);

        }

        [Test] 

        public void Test_GetCoachs_By_TeamNationalityValid()
        {
            TeamLogic teamLogic;
            Mock<IRepository<Team>> mockRepoTeam;
            mockRepoTeam = new Mock<IRepository<Team>>();
            teamLogic = new TeamLogic(mockRepoTeam.Object);

            // Arrange
            string nationality = "American";

            // Mock setup
            mockRepoTeam.Setup(repo => repo.ReadAll()).Returns(new List<Team>
        {
            new Team { Nationality = nationality, Coach = new Coach { CoachName = "Coach1" } },
            new Team { Nationality = nationality, Coach = new Coach { CoachName = "Coach2" } }
        }.AsQueryable());

            // Act
            IEnumerable<Coach> result = teamLogic.GetCoachsByTeamNationality(nationality);

            // Assert
            Assert.AreEqual(2, result.Count());
            Assert.IsTrue(result.All(coach => coach.CoachName.StartsWith("Coach")));
        }

        [Test]

        public void Test_GetPlayersCount_By_TeamIdValid()
        {
            TeamLogic teamLogic;
            Mock<IRepository<Team>> mockRepoTeam;
            mockRepoTeam = new Mock<IRepository<Team>>();
            teamLogic = new TeamLogic(mockRepoTeam.Object);
            // Arrange
            int existingTeamId = 1;

            // Mock setup
             mockRepoTeam.Setup(repo => repo.ReadAll()).Returns(new List<Team>
        {
            new Team { TeamId = existingTeamId, Players = new List<Player> { new Player(), new Player() } }
        }.AsQueryable());

            // Act
            int? result = teamLogic.GetPlayersCountByTeamId(existingTeamId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Value);

        }

        [Test]
        public void Test_get_TheYoungestPlayer_ByTeamIdValid()
        {
            TeamLogic teamLogic;
            Mock<IRepository<Team>> mockRepoTeam;
            mockRepoTeam = new Mock<IRepository<Team>>();
            teamLogic = new TeamLogic(mockRepoTeam.Object);

            // Arrange
            int existingTeamId = 1;

            // Mock adatok beállítása
            mockRepoTeam.Setup(repo => repo.ReadAll()).Returns(new List<Team>
        {
            new Team
            {
                TeamId = existingTeamId,
                Players = new List<Player>
                {
                    new Player { PlayerName = "Player1", Age = 25 },
                    new Player { PlayerName = "Player2", Age = 30 }
                }
            }
        }.AsQueryable());

            // Act
            string result = teamLogic.getTheYoungestPlayerByTeamId(existingTeamId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Player1", result);
        }



    }
}
