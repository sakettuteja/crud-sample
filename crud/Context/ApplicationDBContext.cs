using crud.Model;
using crud.Utility;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crud.Context
{
    public class ApplicationDBContext:IdentityDbContext<User>
    {
        public ApplicationDBContext(DbContextOptions options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Seed();
            builder.ApplyConfiguration(new RoleConfiguration());
            base.OnModelCreating(builder);
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
