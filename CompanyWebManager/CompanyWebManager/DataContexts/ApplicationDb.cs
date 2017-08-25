using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CompanyWebManager.Models;
using CompanyWebManager.Models.ViewModels;
using CompanyWebManager.Models.Views;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CompanyWebManager.DataContexts
{
    public class ApplicationDb : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDb(DbContextOptions<ApplicationDb> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            

            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            builder.Entity<ApplicationUser>().Ignore(c => c.AccessFailedCount)
                                            .Ignore(c => c.LockoutEnabled)
                                            .Ignore(c => c.EmailConfirmed)
                                            .Ignore(c => c.Roles)
                                            .Ignore(c => c.TwoFactorEnabled)
                                            .Ignore(c => c.LockoutEnabled)
                                            .Ignore(c => c.PhoneNumber)
                                            .Ignore(c => c.PhoneNumberConfirmed);

            builder.Entity<ApplicationUser>().ToTable("Users");

            builder.Entity<Company>().ToTable("Companies");
            builder.Entity<Client>().ToTable("Clients");
            builder.Entity<Owner>().ToTable("Owners");            
            builder.Entity<Voivodeship>().ToTable("Voivodeships");
            builder.Entity<Country>().ToTable("Countries");
            builder.Entity<Email>().ToTable("Emails");
            builder.Entity<Employee>().ToTable("Employees");
            builder.Entity<Product>().ToTable("Products");
            builder.Entity<Transaction>().ToTable("Transactions");
            builder.Entity<TransactionDescription>().ToTable("TransactionDescriptions");


        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Voivodeship> Voivodeships { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Transaction> Transaction { get; set; }
        public DbSet<TransactionDescription> TransactionDescription { get; set; }
        public DbSet<ProductsOfTransactions> ProductsOfTransactions { get; set; }

    }
}
