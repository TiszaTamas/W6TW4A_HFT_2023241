using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W6TW4A_HFT_2023241.Models;

namespace W6TW4A_HFT_2023241.Logic.LogicInterfaces
{
    public interface IQuestLogic
    {
        void Create(Quest item);
        void Delete(int id);
        Quest Read(int id);
        IQueryable<Quest> ReadAll();
        void Update(Quest item);
    }
}
