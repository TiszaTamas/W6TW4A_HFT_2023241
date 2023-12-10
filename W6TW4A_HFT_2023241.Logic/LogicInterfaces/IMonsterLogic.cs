using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W6TW4A_HFT_2023241.Models;

namespace W6TW4A_HFT_2023241.Logic.LogicInterfaces
{
    public interface IMonsterLogic
    {
        void Create(Monster item);
        void Delete(int id);
        Monster Read(int id);
        IQueryable<Monster> ReadAll();
        void Update(Monster item);
    }
}
