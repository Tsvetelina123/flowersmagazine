using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Flowersmagazine.Data;

namespace Flowersmagazine.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Flowersmagazine.Data.TypeBouquet> TypeBouquet { get; set; }
        public DbSet<Flowersmagazine.Data.FlowerType> FlowerType { get; set; }


    }
}


