using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using W6TW4A_HFT_2023241.Logic.LogicInterfaces;
using W6TW4A_HFT_2023241.Models;

namespace W6TW4A_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AdventurerController
    {
        IAdventurerLogic logic;
        public AdventurerController(IAdventurerLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<Adventurer> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Adventurer Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Adventurer value)
        {
            this.logic.Create(value);
        }

        [HttpPut]
        public void Put([FromBody] Adventurer value)
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
