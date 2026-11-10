using Microsoft.EntityFrameworkCore;
using MyShop.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop.DAL
{
    public class AppDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=MyShopDb;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
