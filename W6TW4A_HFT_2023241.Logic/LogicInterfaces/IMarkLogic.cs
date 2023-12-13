using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W6TW4A_HFT_2023241.Models;

namespace W6TW4A_HFT_2023241.Logic.LogicInterfaces
{
    public interface IMarkLogic
    {
        void Create(Mark item);
        void Delete(int id);
        Mark Read(int id);
        IQueryable<Mark> ReadAll();
        void Update(Mark item);
        public IEnumerable<Quest> MonsterFinder(int monsterid);
    }
}
