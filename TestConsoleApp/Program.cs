using System;
using W6TW4A_HFT_2023241.Repository;
using W6TW4A_HFT_2023241.Models;
using System.Linq;

namespace TestConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AdventurerGuildDbContext agcx = new AdventurerGuildDbContext();
            var abc = agcx.Monsters.Select(x => x.Name);
            foreach (var item in abc)
            {
                Console.WriteLine(item);
            }
        }
    }
}
