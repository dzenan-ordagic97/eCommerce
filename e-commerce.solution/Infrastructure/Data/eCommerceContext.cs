using Core.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class eCommerceContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public eCommerceContext()
        {
        }
        public eCommerceContext(DbContextOptions<eCommerceContext> options)
             : base(options)
        {
        }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductBrand> ProductBrand { get; set; }
        public DbSet<ProductType> ProductType { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
