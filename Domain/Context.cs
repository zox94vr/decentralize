using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Context : DbContext
    {

        public virtual DbSet<Account> Acconts { get; set; }
        public virtual DbSet<Consultant> Consultants { get; set; }
        public virtual DbSet<ConsultantVendor> ConsultantsVendors { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<Vendor> Vendors { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb; Database=Decentralize;");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Consultant>().ToTable("Consultant");
            modelBuilder.Entity<Vendor>().ToTable("Vendor");
            modelBuilder.Entity<ConsultantVendor>().HasKey(m => new
            {
                m.ConsultantId,
                m.VendorId
            });
        }

    }
}
