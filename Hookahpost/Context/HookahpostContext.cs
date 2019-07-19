using Hookahpost.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hookahpost.Context
{
    public class HookahpostContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=77.245.159.10\MSSQLSERVER2014;Initial Catalog=hookahpostDb; User Id=hookahpostUser;Password=s.a.5050;");
        }
        public DbSet<User> Users { get; set; }
    }
}
