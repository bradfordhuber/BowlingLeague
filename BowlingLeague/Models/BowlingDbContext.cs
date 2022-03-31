﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingLeague.Models
{
    public class BowlingDbContext : DbContext
    {
        public BowlingDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Bowler> Bowlers { get; set; }

        public DbSet<Team> Teams { get; set; }
    }
}
