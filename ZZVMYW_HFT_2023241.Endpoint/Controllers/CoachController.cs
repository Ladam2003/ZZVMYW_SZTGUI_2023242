using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
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
        public CoachController(ICoachLogic logic)
        {
            this.logic = logic;
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
        }

        [HttpPut]
        public void Put([FromBody] Coach value)
        {
            this.logic.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }

    }
}
