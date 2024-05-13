using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using W6TW4A_HFT_2023241.Models;
using W6TW4A_HFT_2023241.Repository.Database;
using W6TW4A_HFT_2023241.Repository.GenericRepository;
using W6TW4A_HFT_2023241.Repository.Interfaces;

namespace W6TW4A_HFT_2023241.Repository.ModelRepositories
{
    public class AdventurerRepository : Repository<Adventurer>, IRepository<Adventurer>
    {
        public AdventurerRepository(AdventurerGuildDbContext agcx) : base(agcx) { }

        public override Adventurer Read(int id)
        {
            return this.agcx.Adventurers.First(x => x.AdventurerId == id);
        }

        //public override void Update(Adventurer item)
        //{
        //    var old = Read(item.AdventurerId);
        //    foreach (var prop in old.GetType().GetProperties())
        //    {
        //        prop.SetValue(old, prop.GetValue(item));
        //    }
        //    agcx.SaveChanges();
        //}

        public override void Update(Adventurer item)
        {
            var old = Read(item.AdventurerId);
            if (old == null)
            {
                throw new ArgumentException("Item not exist..");
            }
            foreach (var prop in old.GetType().GetProperties())
            {
                if (prop.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    prop.SetValue(old, prop.GetValue(item));
                }
            }
            agcx.SaveChanges();
        }

    }
}
