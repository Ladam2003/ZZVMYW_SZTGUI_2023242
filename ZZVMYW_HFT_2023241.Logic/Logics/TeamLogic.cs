using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using ZZVMYW_HFT_2023241.Models;
using ZZVMYW_HFT_2023241.Repository;

namespace ZZVMYW_HFT_2023241.Logic
{
    public class TeamLogic : ITeamLogic
    {
        IRepository<Team> repo;

        public TeamLogic(IRepository<Team> repo)
        {
            this.repo = repo;
        }

        public void Create(Team item)
        {
            if (item.TeamName.Length < 10)
            {
                throw new Exception("Less then 10 character Name does not exist!");
            }
            if (item.TeamName == "")
            {
                throw new Exception("Null TeamName does not exits!");
            }
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }



        public Team Read(int id)
        {
            return this.repo.Read(id);
        }

        public IQueryable<Team> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Team item)
        {
            this.repo.Update(item);
        }

        //NONCRUD
        public double? getAvgPlayersAgeByTeamId(int teamId)
        {
            var result = this.repo.ReadAll().FirstOrDefault(x => x.TeamId == teamId);
            return result?.Players?.Average(p => p.Age);
        }

        public string getTheOldestPlayerByTeamId(int teamId)
        {
            var result = this.repo.ReadAll().FirstOrDefault(t => t.TeamId == teamId);
            var Finalresult = result.Players.OrderByDescending(p => p.Age).First();
            return Finalresult.PlayerName;
        }

        public IEnumerable<Coach> GetCoachsByTeamNationality(string nationality)
        {

            var result = this.repo.ReadAll().Include(team => team.Coach).Where(team => team.Nationality == nationality).Select(team => team.Coach);


            return result;
        }

        public int? GetPlayersCountByTeamId(int teamId)
        {
            var playersCount = this.repo.ReadAll().Include(team => team.Players) .Where(team => team.TeamId == teamId).Select(team => team.Players.Count).FirstOrDefault();

            return playersCount;
        }

        public string getTheYoungestPlayerByTeamId(int teamId)
        {
            var result = this.repo.ReadAll().FirstOrDefault(t => t.TeamId == teamId);
            var Finalresult = result.Players.OrderByDescending(p => p.Age).Last();
            return Finalresult.PlayerName;
        }
    }
    
}
