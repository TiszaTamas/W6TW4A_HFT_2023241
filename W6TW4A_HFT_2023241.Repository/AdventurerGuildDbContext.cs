using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W6TW4A_HFT_2023241.Models;

namespace W6TW4A_HFT_2023241.Repository
{
    internal class AdventurerGuildDbContext : DbContext
    {
        public DbSet<Quest> Quests { get; set; }
        public DbSet<Adventurer> Adventurers { get; set; }
        public DbSet<Monster> Monsters { get; set; }
        public DbSet<Mark> Marks { get; set; }

        public AdventurerGuildDbContext()
        {
            this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
//                string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;
//AttachDbFilename=|DataDirectory|\movies.mdf;Integrated Security=True;MultipleActiveResultSets=true";
                builder
                .UseInMemoryDatabase("adventurersguild")
                .UseLazyLoadingProxies();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Adventurer>(adventurer => adventurer
            .HasOne(adventurer => adventurer.Quest)
            .WithMany(quest=> quest.Adventurer)
            .HasForeignKey(adventurer=>adventurer.Questid)
            .OnDelete(DeleteBehavior.Cascade));

            modelBuilder.Entity<Quest>()
                .HasMany(quest => quest.Monsters)
                .WithMany(monster => monster.Quests)
                .UsingEntity<Mark>(
                role => role.HasOne(role => role.Monster)
                    .WithMany().HasForeignKey(role => role.Monsterid).OnDelete(DeleteBehavior.Cascade),
                role => role.HasOne(role => role.Quest)
                    .WithMany().HasForeignKey(role => role.Questid).OnDelete(DeleteBehavior.Cascade));
        }


    }
}
