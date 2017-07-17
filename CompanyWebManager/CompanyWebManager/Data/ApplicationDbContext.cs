﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CompanyWebManager.Models;

namespace CompanyWebManager.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

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
            builder.Entity<Email>().ToTable("Emails");
            builder.Entity<Owner>().ToTable("Owners");
            builder.Entity<Address>().ToTable("Addresses");
            builder.Entity<Voivodeship>().ToTable("Voivodeships");
            builder.Entity<Country>().ToTable("Countries");
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Voivodeship> Voivodeships { get; set; }
        public DbSet<Country> Countries { get; set; }

    }
}
