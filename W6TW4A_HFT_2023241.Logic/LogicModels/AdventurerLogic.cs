using Castle.Core.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W6TW4A_HFT_2023241.Logic.LogicInterfaces;
using W6TW4A_HFT_2023241.Models;
using W6TW4A_HFT_2023241.Repository.Interfaces;

namespace W6TW4A_HFT_2023241.Logic.LogicModels
{
    public class AdventurerLogic : IAdventurerLogic
    {
        IRepository<Adventurer> repository;

        public AdventurerLogic(IRepository<Adventurer> repository)
        {
            this.repository = repository;
        }
        public void Create(Adventurer item)
        {
            if (item.Name.Length < 4)
            {
                throw new ArgumentException("By the Law of The Continent, an Individuals name must be at least 4 characters long!");
            }
            else if (item.Rank.Equals(null))
            {
                throw new ArgumentException("Rank must at minimum be G1");
            }
            else
            {
                this.repository.Create(item);
            }
        }
        public Adventurer Read(int id)
        {
            var movie = this.repository.Read(id);
            if (movie == null)
            {
                throw new ArgumentException("Adventurer does not exists.");
            }
            return movie;
        }

        public void Delete(int id)
        {
            this.repository.Delete(id);
        }
        public IQueryable<Adventurer> ReadAll()
        {
            return this.repository.ReadAll();
        }
        public void Update(Adventurer item)
        {
            this.repository.Update(item);
        }

        public bool IsAvailable(int id)
        {
            if (id <0)
            {
                return this.repository.Read(id).Quest.Completed;
            }
            else
            {
                throw new ArgumentException("Id provided is wrong");
            }
        }

        public IEnumerable<Adventurer> AllAvailableAdventurersInLocation(string townname)
        {
            if (!townname.IsNullOrEmpty())
            {
                var fromtown = this.repository.ReadAll().Where(x => x.ResidingTown.Equals(townname));
                return fromtown.Where(x => x.Quest.Completed);
            }
            else
            {
                throw new ArgumentNullException("Town name is empty");
            }
        }
    }
}
