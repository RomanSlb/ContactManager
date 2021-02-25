using ContactManager.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManager
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext()
        {

        }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
           : base(options)
        {
    //        Database.EnsureCreated();

        }
        public virtual DbSet<CSVUser> CSVUsers { get; set; }

        public IConfiguration Configuration { get; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string sqlConnectionString = "Server=.\\SQLEXPRESS;Database=ContactManager;Trusted_Connection=True;";
            if (optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(sqlConnectionString,
                    builder => builder.EnableRetryOnFailure());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CSVUser>()
                    .ToTable("ContactManager").HasNoKey();

        }
    }

}
