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
    public class MonsterLogic : IMonsterLogic
    {
        IRepository<Monster> repository;

        public MonsterLogic(IRepository<Monster> repository)
        {
            this.repository = repository;
        }
        public void Create(Monster item)
        {
            if (item.Name.Equals(null))
            {
                throw new ArgumentException("Name is requiered to continue.");
            }
            else
            {
                this.repository.Create(item);
            }
        }
        public Monster Read(int id)
        {
            var movie = this.repository.Read(id);
            if (movie == null)
            {
                throw new ArgumentException("Monster does not exists.");
            }
            return movie;
        }

        public void Delete(int id)
        {
            this.repository.Delete(id);
        }
        public IQueryable<Monster> ReadAll()
        {
            return this.repository.ReadAll();
        }
        public void Update(Monster item)
        {
            this.repository.Update(item);
        }


    }
}
