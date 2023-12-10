using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W6TW4A_HFT_2023241.Models;

namespace W6TW4A_HFT_2023241.Repository.Database
{
    public class AdventurerGuildDbContext : DbContext
    {
        public DbSet<Quest> Quests { get; set; }
        public DbSet<Adventurer> Adventurers { get; set; }
        public DbSet<Monster> Monsters { get; set; }
        public DbSet<Mark> Marks { get; set; }

        public AdventurerGuildDbContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                //                string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;
                //AttachDbFilename=|DataDirectory|\TestDatabase.mdf;Integrated Security=True;MultipleActiveResultSets=true";

                builder
                //.UseSqlServer(conn)
                .UseInMemoryDatabase("adventurersguild")
                .UseLazyLoadingProxies();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Adventurer>(adventurer => adventurer
            .HasOne(adventurer => adventurer.Quest)
            .WithMany(quest => quest.Adventurers)
            .HasForeignKey(adventurer => adventurer.QuestId)
            .OnDelete(DeleteBehavior.Cascade));

            modelBuilder.Entity<Quest>()
                .HasMany(quest => quest.Monsters)
                .WithMany(monster => monster.Quests)
                .UsingEntity<Mark>(
                mark => mark.HasOne(mark => mark.Monster)
                    .WithMany().HasForeignKey(role => role.MonsterId).OnDelete(DeleteBehavior.Cascade),
                mark => mark.HasOne(mark => mark.Quest)
                    .WithMany().HasForeignKey(role => role.QuestId).OnDelete(DeleteBehavior.Cascade));

            modelBuilder.Entity<Mark>()
                .HasOne(mark => mark.Quest)
                .WithMany(q => q.Marks)
                .HasForeignKey(m => m.QuestId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Mark>()
                .HasOne(mark => mark.Monster)
                .WithMany(q => q.Marks)
                .HasForeignKey(m => m.MonsterId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Monster>().HasData(new Monster[]
            {
                new Monster("1/Blazing Phoenix/B7/Majestic, fiery bird with wings that leave trails of embers and a scorching beak./Susceptible to water-based attacks, majestic flight can be disrupted by strong winds./Burning feathers for potent fire-based concoctions, searing beak for crafting fiery weapons.")
                ,new Monster("2/Murmurbat Hatchling/E5/Tiny bat with delicate wings and a timid demeanor./Susceptible to sudden movements, easily scared by larger creatures./Murmurbat fangs for crafting minor potions, soft wings for decorative trinkets.")
                ,new Monster("3/Mossy Whiskertail/C1/Small, moss-covered rodent with a slow, lumbering gait./Vulnerable to dry environments, sluggish movement in direct sunlight./Whiskertail fur for crafting rustic textiles, mossy hide for basic camouflage.")
                ,new Monster("4/Timid Spritelight/F3/Tiny, glowing sprite with delicate wings and a shy demeanor./Vulnerable to sudden movements, easily frightened by loud noises./Luminous dust for faint illumination, fragile wings for decorative crafts.")
                ,new Monster("5/Spectral Direwolf/B8/Ghostly wolf with transparent fur and a haunting howl that chills the bones./Susceptible to banishment spells, fearful of powerful holy symbols./Ectoplasmic fur for crafting ethereal garments, ghostly fangs for spectral weaponry.")
                ,new Monster("6/Thunderstrike Griffin/B8/Majestic, eagle-headed creature with electrically charged feathers and crackling talons./Vulnerable to grounding attacks, electrically insulating materials can mitigate damage./Electrically charged feathers for crafting enchanted arrows, talons for conductive materials.")
            });

            modelBuilder.Entity<Mark>().HasData(new Mark[]
            {
                new Mark("1/1/2"),
                new Mark("2/1/3"),
                new Mark("3/2/2"),
                new Mark("4/3/3"),
                new Mark("5/2/4"),
                new Mark("6/4/6")
            });

            modelBuilder.Entity<Quest>().HasData(new Quest[]
            {
                new Quest("1/Rescue the Lost Scholar/E4/Arcane Academy/Ancient tome of magical knowledge",true),
                new Quest("2/Herb Gathering Expedition/D2/Herbalist Guild/Pouch of gold and rare potion ingredients",false),
                new Quest("3/Locate the Missing Explorer/D3/Explorers' Guild/Unique map revealing hidden locations",true),
                new Quest("4/Subdue the Thunderstrike Griffin/B9/Skywatch Tower/Flying mount and a treasure trove of jewels",false)
            });

            modelBuilder.Entity<Adventurer>().HasData(new Adventurer[]
            {
                new Adventurer("1/2/Garrick Stoneforge/Hallowed Guardians/E3/Ironhold Stronghold"),
                new Adventurer("2/2/Sylas Emberbane/Hallowed Guardians/D1/Emberfall Keep"),
                new Adventurer("3/1/Roderick Shadowblade/Nightfall Rogues/F4/Shadow's Edge"),
                new Adventurer("4/3/Kael Sunfire/Sunfire Crusaders/D6/Radiant Citadel"),
                new Adventurer("5/4/Luna Starshaper/Celestial Seekers/S5/Stardust Haven")
            });
        }
        //string[] split = a.Split("/");
        //AdventurerId = int.Parse(split[0]);
        //QuestId = int.Parse(split[1]);
        //Name = split[2];
        //    PartyName = split[3];
        //    Rank = split[4];
        //    ResidingTown = split[5];
    }
}
