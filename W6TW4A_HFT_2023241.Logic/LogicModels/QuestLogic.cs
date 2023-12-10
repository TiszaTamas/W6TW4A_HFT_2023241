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
    public class QuestLogic : IQuestLogic
    {
        IRepository<Quest> repository;

        public QuestLogic(IRepository<Quest> repository)
        {
            this.repository = repository;
        }
        public void Create(Quest item)
        {
            if (item.Objective.Length<10)
            {
                throw new ArgumentException("Please write a longer description of the objective.");
            }
            else if (item.Completed)
            {
                throw new ArgumentException("Quest cannot be completed at creation.");
            }
            else
            {
                this.repository.Create(item);
            }
        }
        public Quest Read(int id)
        {
            var movie = this.repository.Read(id);
            if (movie == null)
            {
                throw new ArgumentException("Quest does not exists.");
            }
            return movie;
        }

        public void Delete(int id)
        {
            this.repository.Delete(id);
        }
        public IQueryable<Quest> ReadAll()
        {
            return this.repository.ReadAll();
        }
        public void Update(Quest item)
        {
            this.repository.Update(item);
        }


    }
}
