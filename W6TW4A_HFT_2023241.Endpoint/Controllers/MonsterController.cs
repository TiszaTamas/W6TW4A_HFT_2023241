using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using W6TW4A_HFT_2023241.Logic.LogicInterfaces;
using W6TW4A_HFT_2023241.Models;

namespace W6TW4A_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MonsterController
    {
        IMonsterLogic logic;
        public MonsterController(IMonsterLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<Monster> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Monster Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Monster value)
        {
            this.logic.Create(value);
        }

        [HttpPut]
        public void Put([FromBody] Monster value)
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
