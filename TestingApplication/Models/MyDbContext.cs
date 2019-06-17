using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TestingApplication.Models
{
    public class MyDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        //public DbSet<Answer> Answers { get; set; }
        public MyDbContext(DbContextOptions<MyDbContext> options):base(options)
        {
            Database.EnsureCreated();
        }
    }
}
