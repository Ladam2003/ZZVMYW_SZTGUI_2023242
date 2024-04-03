using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.IO;
using ZZVMYW_HFT_2023241.Endpoint.Services;
using ZZVMYW_HFT_2023241.Logic;
using ZZVMYW_HFT_2023241.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ZZVMYW_HFT_2023241.Endpoint
{
    [Route("[controller]")]
    [ApiController]
    public class CoachController : ControllerBase
    {
        ICoachLogic logic;
        IHubContext<SignalRHub> hub;
        public CoachController(ICoachLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Coach> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Coach Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Coach value)
        {
            this.logic.Create(value);
            this.hub.Clients.All.SendAsync("CoachCreated", value);
        }

        [HttpPut]
        public void Put([FromBody] Coach value)
        {
            this.logic.Update(value);
            this.hub.Clients.All.SendAsync("CoachUpdated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var coachToDelete = this.logic.Read(id);
            this.logic.Delete(id);
            this.hub.Clients.All.SendAsync("CoachDeleted", coachToDelete);
        }

    }
}
