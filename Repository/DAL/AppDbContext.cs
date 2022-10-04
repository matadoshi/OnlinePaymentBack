using DomainModels.Entities;
using DomainModels.PaymentModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.DAL
{
    public class AppDbContext:IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Slider> Sliders{ get; set; }
        public DbSet<Customer> Customers{ get; set; }
        public DbSet<Attributes> Attributes{ get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Invoice> Invoices{ get; set; }
        public DbSet<Transaction> Transactions{ get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
