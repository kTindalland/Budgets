using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Database.Entities;

namespace Database
{
    public class BudgetContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Fuel> FuelRecords { get; set; }
        public DbSet<Income> IncomeRecords { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Budget> Budgets { get; set; }

        public BudgetContext(DbContextOptions options) : base(options)
        {
        }

    }
}
