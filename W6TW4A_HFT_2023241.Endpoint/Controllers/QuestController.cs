using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using W6TW4A_HFT_2023241.Logic.LogicInterfaces;
using W6TW4A_HFT_2023241.Models;

namespace W6TW4A_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class QuestController
    {
        IQuestLogic logic;
        public QuestController(IQuestLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<Quest> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Quest Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Quest value)
        {
            this.logic.Create(value);
        }

        [HttpPut]
        public void Put([FromBody] Quest value)
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
