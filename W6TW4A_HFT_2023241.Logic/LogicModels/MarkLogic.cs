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
    public class MarkLogic : IMarkLogic
    {
        IRepository<Mark> repository;

        public MarkLogic(IRepository<Mark> repository)
        {
            this.repository = repository;
        }
        public void Create(Mark item)
        {
            if (item.MonsterId<0||item.QuestId<0)
            {
                throw new ArgumentException("Quest and Monster ID must be positive.");
            }
            else
            {
                this.repository.Create(item);
            }
        }
        public Mark Read(int id)
        {
            var movie = this.repository.Read(id);
            if (movie == null)
            {
                throw new ArgumentException("Mark does not exists.");
            }
            return movie;
        }

        public void Delete(int id)
        {
            this.repository.Delete(id);
        }
        public IQueryable<Mark> ReadAll()
        {
            return this.repository.ReadAll();
        }
        public void Update(Mark item)
        {
            this.repository.Update(item);
        }

        public IEnumerable<Quest> MonsterFinder(int monsterid)
        {
            var quests = this.repository.ReadAll().Where(x => x.MonsterId == monsterid).Select(x=>x.Quest);
            return quests;
        }
    }
}
