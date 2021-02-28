using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Context : DbContext
    {
        public Context()
        {

        }
        public virtual DbSet<Account> Acconts { get; set; }
        public virtual DbSet<Consultant> Consultants { get; set; }
        public virtual DbSet<ConsultantVendor> ConsultantsVendors { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<Vendor> Vendors { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
