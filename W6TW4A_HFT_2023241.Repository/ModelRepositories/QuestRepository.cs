using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using W6TW4A_HFT_2023241.Models;
using W6TW4A_HFT_2023241.Repository.Database;
using W6TW4A_HFT_2023241.Repository.GenericRepository;
using W6TW4A_HFT_2023241.Repository.Interfaces;

namespace W6TW4A_HFT_2023241.Repository.ModelRepositories
{
    public class QuestRepository : Repository<Quest>, IRepository<Quest>
    {
        public QuestRepository(AdventurerGuildDbContext agcx): base(agcx) { }

        public override Quest Read(int id)
        {
            return this.agcx.Quests.First(x => x.QuestId==id);
        }

        public override void Update(Quest item)
        {
            var old = Read(item.QuestId);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            agcx.SaveChanges();
        }

    }
}
