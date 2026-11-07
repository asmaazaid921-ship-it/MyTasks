using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using taaask10.model;

namespace taaask10.data
{
    internal class SalesDbContext:DbContext
    {
         
        public DbSet<Product> Products { get; set; }
        public DbSet<Customers> Customers{ get; set; }

        public DbSet<Sales> Sales { get; set; }
        public DbSet<Store> Stores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Data Source=. ; initial Catalog = taaask10; Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;");
        }
    }
}

