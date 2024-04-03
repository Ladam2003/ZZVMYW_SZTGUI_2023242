using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using ZZVMYW_HFT_2023241.Endpoint.Services;
using ZZVMYW_HFT_2023241.Logic;
using ZZVMYW_HFT_2023241.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ZZVMYW_HFT_2023241.Endpoint
{
    [Route("[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        ITeamLogic logic;
        IHubContext<SignalRHub> hub;
        public TeamController(ITeamLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Team> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Team Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Team value)
        {
            this.logic.Create(value);
            this.hub.Clients.All.SendAsync("TeamCreated", value);
        }

        [HttpPut]
        public void Update([FromBody] Team value)
        {
            this.logic.Update(value);
            this.hub.Clients.All.SendAsync("TeamUpdated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var TeamToDelete = this.logic.Read(id);
            this.logic.Delete(id);
            this.hub.Clients.All.SendAsync("TeamDeleted", TeamToDelete);
        }
    }
}
