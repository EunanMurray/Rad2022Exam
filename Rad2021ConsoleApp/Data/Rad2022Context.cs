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
                new Members { MemberID = 1, Name = "Elizabeth Anderson", Address = "8 Johnston Road, Dublin", Phone = "(01)-12345322", ShareBalance = 200.00 },
                new Members { MemberID = 2, Name = "Catherine Autier Miconi", Address = "Garden House Crowther Way, Dublin 20", Phone = "(01)-62634562", ShareBalance = 400.00 },
                new Members { MemberID = 3, Name = "Thomas Axen", Address = "1900 Oak St., Dublin 4", Phone = "(01)-89377483", ShareBalance = 2000.00 },
                new Members { MemberID = 4, Name = "John B. Aird", Address = "8 Johnston Road, Dublin", Phone = "(01)-12345322", ShareBalance = 800.00 },
                new Members { MemberID = 5, Name = "Elizabeth Anderson", Address = "8 Johnston Road, Dublin", Phone = "(01)-12345322", ShareBalance = 600.00 },
                new Members { MemberID = 6, Name = "Elizabeth Anderson", Address = "8 Johnston Road, Dublin", Phone = "(01)-12345322", ShareBalance = 3000.00 },
                new Members { MemberID = 7, Name = "Elizabeth Anderson", Address = "8 Johnston Road, Dublin", Phone = "(01)-12345322", ShareBalance = 5000.00 }
                );

            modelBuilder.Entity<Loans>().HasData(
               new Loans { LoanID = 1, MemberID = 1, ApplicationDate = new DateTime(2020, 7, 14), LoanAmount = 67.00m, ApprovalDate = null, Approved = false, ApprovedBy = null, RepaidInFull = false },
               new Loans { LoanID = 2, MemberID = 1, ApplicationDate = new DateTime(2020, 3, 29), LoanAmount = 315.00m, ApprovalDate = new DateTime(2020, 4, 2), Approved = true, ApprovedBy = "Paul", RepaidInFull = true },
               new Loans { LoanID = 3, MemberID = 2, ApplicationDate = new DateTime(2020, 3, 13), LoanAmount = 2089.00m, ApprovalDate = new DateTime(2020, 3, 19), Approved = true, ApprovedBy = "Paul", RepaidInFull = false },
               new Loans { LoanID = 4, MemberID = 3, ApplicationDate = new DateTime(2020, 9, 26), LoanAmount = 6000.00m, ApprovalDate = null, Approved = false, ApprovedBy = null, RepaidInFull = false },
               new Loans { LoanID = 5, MemberID = 4, ApplicationDate = new DateTime(2020, 6, 20), LoanAmount = 157.00m, ApprovalDate = null, Approved = false, ApprovedBy = null, RepaidInFull = false },
               new Loans { LoanID = 6, MemberID = 5, ApplicationDate = new DateTime(2020, 2, 14), LoanAmount = 4205.00m, ApprovalDate = new DateTime(2020, 2, 16), Approved = true, ApprovedBy = "Bill", RepaidInFull = false }
            );
        }

        public Rad2022Context()
        {
        }

        public Rad2022Context(DbContextOptions<Rad2022Context> options) : base(options)
        {
        }
    }
}
