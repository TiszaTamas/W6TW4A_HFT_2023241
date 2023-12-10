using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using W6TW4A_HFT_2023241.Models;

namespace W6TW4A_HFT_2023241.Logic.LogicInterfaces
{
    public interface IAdventurerLogic
    {
        void Create(Adventurer item);
        void Delete(int id);
        Adventurer Read(int id);
        IQueryable<Adventurer> ReadAll();
        void Update(Adventurer item);
    }
}
