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
    public class RoleController : ControllerBase
    {
        IRoleLogic logic;
        IHubContext<SignalRHub> hub;
        public RoleController(IRoleLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Role> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Role Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Role value)
        {
            this.logic.Create(value);
            this.hub.Clients.All.SendAsync("RoleCreated", value);
        }

        [HttpPut]
        public void Put([FromBody] Role value)
        {
            this.logic.Update(value);
            this.hub.Clients.All.SendAsync("RoleUpdated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var RoleToDelete = this.logic.Read(id);
            this.logic.Delete(id);
            this.hub.Clients.All.SendAsync("RoleDeleted", RoleToDelete);
        }
    }
}
