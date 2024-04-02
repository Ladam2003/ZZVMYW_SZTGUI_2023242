using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ZZVMYW_HFT_2023241.Logic;
using ZZVMYW_HFT_2023241.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ZZVMYW_HFT_2023241.Endpoint
{
    [Route("[controller]/[Action]")]
    [ApiController]
    public class NonCrudController : ControllerBase
    {
        ITeamLogic logic;

        public NonCrudController(ITeamLogic logic)
        {
            this.logic = logic;
        }
        [HttpGet("Get average players age by teamId")]
        public double? getAvgPlayersAgeByTeamId(int teamId)
        {
            return this.logic.getAvgPlayersAgeByTeamId(teamId);
        }
        [HttpGet("Get the oldest player by teamId")]
        public string getTheOldestPlayerByTeamId(int teamId)
        {
            return this.logic.getTheOldestPlayerByTeamId(teamId);
        }
        [HttpGet("Get Coachs by team natioanlity")]
        public IEnumerable<Coach> GetCoachsByTeamNationality(string nationality)
        {
            return this.logic.GetCoachsByTeamNationality(nationality);
        }
        [HttpGet("Get players count by teamId")]
        public int? GetPlayersCountByTeamId(int teamId)
        {
            return this.logic.GetPlayersCountByTeamId(teamId);
        }
        [HttpGet("Get the youngest player by teamId")]
        public string getTheYoungestPlayerByTeamId(int teamId)
        {
            return this.logic.getTheYoungestPlayerByTeamId(teamId);
        }
    }
}
