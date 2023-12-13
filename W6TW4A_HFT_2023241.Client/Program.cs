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
                Quest one = rest.Get<Quest>(id, "monster");
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

        static void Main(string[] args)
        {
            rest = new RestService("http://localhost:8351/", "adventurersguild");

            var monsterSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Monster"))
                .Add("Create", () => Create("Monster"))
                .Add("Delete", () => Delete("Monster"))
                .Add("Update", () => Update("Monster"))
                .Add("Exit", ConsoleMenu.Close);

            var adventurerSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Adventurer"))
                .Add("Create", () => Create("Adventurer"))
                .Add("Delete", () => Delete("Adventurer"))
                .Add("Update", () => Update("Adventurer"))
                .Add("Exit", ConsoleMenu.Close);

            var questSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Quest"))
                .Add("Create", () => Create("Quest"))
                .Add("Delete", () => Delete("Quest"))
                .Add("Update", () => Update("Quest"))
                .Add("Exit", ConsoleMenu.Close);


            var menu = new ConsoleMenu(args, level: 0)
                .Add("Quests", () => questSubMenu.Show())
                .Add("Monsters", () => monsterSubMenu.Show())
                .Add("Marks", () => adventurerSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();
        }
    }
}
