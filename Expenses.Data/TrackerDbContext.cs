﻿using Expenses.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expenses.Data
{
    public class TrackerDbContext : DbContext
    {
     
        public TrackerDbContext(DbContextOptions<TrackerDbContext> options) : base(options)
        {
            
        }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
