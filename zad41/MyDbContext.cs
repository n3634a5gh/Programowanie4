using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad41
{
    internal class MyDbContext : DbContext
    {
        public DbSet<Author>Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-IKCEP9LL\SQLEXPRESS;Initial Catalog=PV2-Library1;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);
            modelbuilder.Entity<Author>().Property("Id")
                .IsRequired()
                .HasMaxLength(50);
            modelbuilder.Entity<Book>().Property("Id")
                .IsRequired()
                .HasMaxLength(50);
            modelbuilder.Entity<Author>().Property("Name")
                .IsRequired();
            modelbuilder.Entity<Author>().Property("LastName")
                .IsRequired();
            modelbuilder.Entity<Book>().Property("Title")  
                .IsRequired();
            modelbuilder.Entity<Book>().Property("Year")
                .IsRequired();
        }
    }
}
