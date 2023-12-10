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
    public class MarkRepository : Repository<Mark>, IRepository<Mark>
    {
        public MarkRepository(AdventurerGuildDbContext agcx) : base(agcx) { }

        public override Mark Read(int id)
        {
            return this.agcx.Marks.First(x => x.MarkId == id);
        }

        public override void Update(Mark item)
        {
            var old = Read(item.MarkId);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            agcx.SaveChanges();
        }

    }
}
