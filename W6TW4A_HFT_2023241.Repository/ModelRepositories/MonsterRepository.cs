using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W6TW4A_HFT_2023241.Models;
using W6TW4A_HFT_2023241.Repository.Database;
using W6TW4A_HFT_2023241.Repository.GenericRepository;
using W6TW4A_HFT_2023241.Repository.Interfaces;

namespace W6TW4A_HFT_2023241.Repository.ModelRepositories
{
    public class MonsterRepository : Repository<Monster>, IRepository<Monster>
    {
        public MonsterRepository(AdventurerGuildDbContext agcx) : base(agcx) { }

        public override Monster Read(int id)
        {
            return this.agcx.Monsters.First(x => x.MonsterId == id);
        }

        public override void Update(Monster item)
        {
            var old = Read(item.MonsterId);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            agcx.SaveChanges();
        }

    }
}
