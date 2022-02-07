﻿using Les2EFIntro.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Les2EFIntro.Data
{
    public class TeamManagmentDBContext : DbContext
    {
        public DbSet<Member> Members { get; set; } = null!;

        public DbSet<Team> Teams { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\MSSQLLocalDB;Database=TeamManagementEF;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Member>().HasData(
                new Member { Id = 1001, Name = "Henk", Email = "henk@breda.nl", TeamId = 201 },
                new Member { Id = 1002, Name = "Loes", Email = "loes@avans.nl", TeamId = 201 }
       );

            modelBuilder.Entity<Team>().HasData(
                new Team { Id = 201, Group = "Groep-1", Title = "You snooze, you loose!" },
                new Team { Id = 202, Group = "Groep-2", Title = "Nachos" },
                new Team { Id = 203, Group = "Groep-3", Title = "3 front-end devs + 1 back-end dev" },
                new Team { Id = 204, Group = "Groep-4", Title = "Cinavas" }
                );
        }

    }
}
