using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Rad2021ClassLibrary.Models;


namespace Rad2021ConsoleApp.Data
{
    public class Rad2022Context : DbContext
    {
        public DbSet<Loans> Loans { get; set; }
        public DbSet<Members> Members { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Rad2022Db;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Loans>()
                .HasKey(l => l.LoanID);

            modelBuilder.Entity<Members>()
                .HasKey(m => m.MemberID);

            modelBuilder.Entity<Loans>()
                .HasOne(l => l.Member)
                .WithMany(m => m.Loan)
                .HasForeignKey(l => l.MemberID);

            modelBuilder.Entity<Members>().HasData(
                new Members { MemberID = 1, Name = "Elizabeth Anderson", Address = "8 Johnston Road, Dublin", Phone = "(01)-12345322"},
                new Members { MemberID = 2, Name = "Catherine Autier Miconi", Address = "Garden House Crowther Way, Dublin 20", Phone = "(01)-62634562"},
                new Members { MemberID = 3, Name = "Thomas Axen", Address = "1900 Oak St., Dublin 4", Phone = "(01)-89377483" },
                new Members { MemberID = 4, Name = "John B. Aird", Address = "8 Johnston Road, Dublin", Phone = "(01)-12345322" },
                new Members { MemberID = 5, Name = "Elizabeth Anderson", Address = "8 Johnston Road, Dublin", Phone = "(01)-12345322" },
                new Members { MemberID = 6, Name = "Elizabeth Anderson", Address = "8 Johnston Road, Dublin", Phone = "(01)-12345322" },
                new Members { MemberID = 7, Name = "Elizabeth Anderson", Address = "8 Johnston Road, Dublin", Phone = "(01)-12345322" }
                );

            modelBuilder.Entit
        }
    }
}
