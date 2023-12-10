using System;
using W6TW4A_HFT_2023241.Models;
using System.Linq;
using W6TW4A_HFT_2023241.Repository.Database;

namespace TestConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AdventurerGuildDbContext agcx = new AdventurerGuildDbContext();
            foreach (var item in agcx.Quests)
            {
                Console.WriteLine(item.Objective);
                foreach (var mark in item.Marks)
                {
                    Console.WriteLine("\t"+mark.Monster.Name);
                }
            }
        }
    }
}
