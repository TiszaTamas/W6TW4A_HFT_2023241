using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using W6TW4A_HFT_2023241.Logic.LogicInterfaces;
using W6TW4A_HFT_2023241.Models;

namespace W6TW4A_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class NoncrudController: ControllerBase
    {
        IAdventurerLogic alogic;
        IMarkLogic mlogic;
        IQuestLogic qlogic;
        public NoncrudController(IAdventurerLogic alogic,IMarkLogic mlogic,IQuestLogic qlogic)
        {
            this.alogic = alogic;
            this.mlogic = mlogic;
            this.qlogic = qlogic;
        }

        [HttpGet("{id}")]
        public bool IsAvailable(int id)
        {
            return this.alogic.IsAvailable(id);
        }

        [HttpGet("{id}")]
        public IEnumerable<Adventurer> AllAvailableAdventurersInLocation(string id)
        {
            return this.alogic.AllAvailableAdventurersInLocation(id);
        }

        [HttpGet("{id}")]
        public IEnumerable<Adventurer> AdventurersForQuest(int id)
        {
            return this.qlogic.AdventurersForQuest(id);
        }

        [HttpGet("{id}")]
        public Adventurer HighestAdventurerOnQuest(int id)
        {
            return this.qlogic.HighestAdventurerOnQuest(id);
        }

        [HttpGet("{id}")]
        public IEnumerable<Quest> MonsterFinder(int id)
        {
            return this.mlogic.MonsterFinder(id);
        }
    }
    
}
