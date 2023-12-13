using ConsoleTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using W6TW4A_HFT_2023241.Models;

namespace W6TW4A_HFT_2023241.Client
{
    internal class Program
    {
        static RestService rest;

        static void Create(string entity)
        {
            if (entity == "Monster")
            {
                Console.Write("Enter Monster Name: ");
                string name = Console.ReadLine();
                rest.Post(new Monster() { Name = name }, "monster");
            }
            else if (entity == "Quest")
            {
                Console.Write("Enter Quest Objective: ");
                string objective = Console.ReadLine();
                rest.Post(new Quest() { Objective = objective }, "quest");
            }
            else if (entity == "Adventurer")
            {
                Console.Write("Enter Adventurer Name: ");
                string name = Console.ReadLine();
                rest.Post(new Adventurer() { Name = name }, "adventurer");
            }
        }
        static void List(string entity)
        {
            if (entity == "Monster")
            {
                List<Monster> monsters = rest.Get<Monster>("monster");
                foreach (var item in monsters)
                {
                    Console.WriteLine(item.MonsterId + "__" + item.Name + "__" + item.Appearance + "__" + item.Weakness + "__" + item.UsefulParts + "__" + item.Rank);
                }
            }
            else if (entity == "Quest")
            {
                List<Quest> monsters = rest.Get<Quest>("quest");
                foreach (var item in monsters)
                {
                    Console.WriteLine(item.QuestId + "__" + item.Objective + "__" + item.Reward + "__" + item.ClientName + "__" + item.DifficultyRating + "__" + item.Completed);
                }
            }
            else if (entity == "Adventurer")
            {
                List<Adventurer> monsters = rest.Get<Adventurer>("adventurer");
                foreach (var item in monsters)
                {
                    Console.WriteLine(item.AdventurerId + "__" + item.Name + "__" + item.Rank + "__" + item.PartyName + "__" + item.ResidingTown);
                }
            }

            Console.ReadLine();
        }
        static void Update(string entity)
        {
            if (entity == "Monster")
            {
                Console.Write("Enter Monster's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Monster one = rest.Get<Monster>(id, "monster");
                Console.Write($"New name [old: {one.Name}]: ");
                string name = Console.ReadLine();
                one.Name = name;
                rest.Put(one, "monster");
            }
            if (entity == "Adventurer")
            {
                Console.Write("Enter Adventurer's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Adventurer one = rest.Get<Adventurer>(id, "adventurer");
                Console.Write($"New name [old: {one.Name}]: ");
                string name = Console.ReadLine();
                one.Name = name;
                rest.Put(one, "adventurer");
            }
            if (entity == "Quest")
            {
                Console.Write("Enter Quest's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Quest one = rest.Get<Quest>(id, "quest");
                Console.Write($"New objective [old: {one.Objective}]: ");
                string objective = Console.ReadLine();
                one.Objective = objective;
                rest.Put(one, "quest");
            }
        }
        static void Delete(string entity)
        {
            if (entity == "Monster")
            {
                Console.Write("Enter Monster's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "monster");
            }
            else if (entity == "Quest")
            {
                Console.Write("Enter Quest's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "quest");
            }
            else if (entity == "Adventurer")
            {
                Console.Write("Enter Adventurer's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "adventurer");
            }
        }

        static void IsAvailable(string entity)
        {
            Console.WriteLine("Enter Adventurer's id to see if they are available");
            int id = int.Parse(Console.ReadLine());
            bool a = rest.Get<bool>(id, "noncrud/IsAvailable");
            if (a)
            {
                Console.WriteLine("They are available");
            }
            else
            {
                Console.WriteLine("They are not available");
            }
            Console.ReadKey();
        }

        static void AllAvailableAdventurersInLocation(string entity)
        {
            Console.WriteLine("Enter Town name, to see available adventurers");
            string id = Console.ReadLine();
            string nothing="";
            List<Adventurer> adventurers = rest.Get<Adventurer>(id, "noncrud/AllAvailableAdventurersInLocation", nothing);
            Console.WriteLine("Available adventurers:");
            foreach (var item in adventurers)
            {
                Console.WriteLine(item.Name);
            }
            Console.ReadKey();
        }


        static void AdventurersForQuest(string entity)
        {
            Console.WriteLine("Eneter Quest Id to see same rank Adventrers");
            int id =int.Parse( Console.ReadLine());
            int nothing=0;
            List<Adventurer> adventurers = rest.Get<Adventurer>(id, "noncrud/AdventurersForQuest", nothing);
            Console.WriteLine("In Rank Adventurers:");
            foreach (var item in adventurers)
            {
                Console.WriteLine(item.Name);
            }
            Console.ReadKey();
        }

        static void HighestAdventurerOnQuest(string entity)
        {
            Console.WriteLine("Eneter Quest Id to see the highest Adventurer in the Quest");
            int id = int.Parse(Console.ReadLine());
            Adventurer adventurer = rest.Get<Adventurer>(id, "noncrud/HighestAdventurerOnQuest");
            Console.WriteLine("Highest Rank Adventurer:");
            Console.WriteLine(adventurer.Name);
            Console.ReadKey();

        }

        static void MonsterFinder(string entityd)
        {
            Console.WriteLine("Eneter Monster Id to search quests, with the same monster");
            int id = int.Parse(Console.ReadLine());
            int nothing = 0;
            List<Quest> adventurers = rest.Get<Quest>(id, "noncrud/MonsterFinder", nothing);
            Console.WriteLine("Desired Quests:");
            foreach (var item in adventurers)
            {
                Console.WriteLine(item.QuestId + " ID: " +item.Objective);
            }
            Console.ReadKey();
        }

        //[HttpGet("{id}")]
        //public IEnumerable<Adventurer> AdventurersForQuest(int id)
        //{
        //    return this.qlogic.AdventurersForQuest(id);
        //}

        //[HttpGet("{id}")]
        //public Adventurer HighestAdventurerOnQuest(int id)
        //{
        //    return this.qlogic.HighestAdventurerOnQuest(id);
        //}

        //[HttpGet("{id}")]
        //public IEnumerable<Quest> MonsterFinder(int monsterid)
        //{
        //    return this.mlogic.MonsterFinder(monsterid);
        //}

        static void Main(string[] args)
        {
            rest = new RestService("http://localhost:8351/", "adventurersguild");

            var monsterSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Monster"))
                .Add("Create", () => Create("Monster"))
                .Add("Delete", () => Delete("Monster"))
                .Add("Update", () => Update("Monster"))
                .Add("MonsterFinder", () => MonsterFinder("Monster"))
                .Add("Exit", ConsoleMenu.Close);

            var adventurerSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Adventurer"))
                .Add("Create", () => Create("Adventurer"))
                .Add("Delete", () => Delete("Adventurer"))
                .Add("Update", () => Update("Adventurer"))
                .Add("IsAvailable", ()=> IsAvailable("Adventurer"))
                .Add("AllAvailableAdventurersInLocation", ()=> AllAvailableAdventurersInLocation("Adventurer"))
                .Add("Exit", ConsoleMenu.Close);

            var questSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Quest"))
                .Add("Create", () => Create("Quest"))
                .Add("Delete", () => Delete("Quest"))
                .Add("Update", () => Update("Quest"))
                .Add("AdventurersForQuest", () => AdventurersForQuest("Adventurer"))
                .Add("HighestAdventurerOnQuest", () => HighestAdventurerOnQuest("Adventurer"))
                .Add("Exit", ConsoleMenu.Close);


            var menu = new ConsoleMenu(args, level: 0)
                .Add("Quests", () => questSubMenu.Show())
                .Add("Monsters", () => monsterSubMenu.Show())
                .Add("Adventurers", () => adventurerSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();
        }
    }
}
