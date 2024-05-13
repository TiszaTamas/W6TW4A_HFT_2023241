using Castle.Core.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using W6TW4A_HFT_2023241.Endpoint.Services;
using W6TW4A_HFT_2023241.Logic.LogicInterfaces;
using W6TW4A_HFT_2023241.Models;

namespace W6TW4A_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AdventurerController
    {
        IAdventurerLogic logic;
        IHubContext<SignalRHub> hub;

        public AdventurerController(IAdventurerLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
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
            this.hub.Clients.All.SendAsync("AdventurerCreated", value);
        }

        [HttpPut]
        public void Put([FromBody] Adventurer value)
        {
            this.logic.Update(value);
            this.hub.Clients.All.SendAsync("AdventurerUpdated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var advToDelete = this.logic.Read(id);
            this.logic.Delete(id);
            this.hub.Clients.All.SendAsync("AdventurerDeleted", advToDelete);
        }

        //public bool IsAvailable(int id)
        //{
        //    if (id > 0)
        //    {
        //        var a = this.repository.Read(id).Quest.Completed;
        //        return a;
        //    }
        //    else
        //    {
        //        throw new ArgumentException("Id provided is wrong");
        //    }
        //}

        //public IEnumerable<Adventurer> AllAvailableAdventurersInLocation(string townname)
        //{
        //    if (!townname.IsNullOrEmpty())
        //    {
        //        var fromtown = this.repository.ReadAll().Where(x => x.ResidingTown.Equals(townname));
        //        return fromtown.Where(x => x.Quest.Completed);
        //    }
        //    else
        //    {
        //        throw new ArgumentNullException("Town name is empty");
        //    }
        //}
    }
}
