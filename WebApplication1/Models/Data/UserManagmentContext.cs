using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebApplication1.Models;

namespace WebApplication1.Models.Data
{
    public partial class UserManagmentContext : DbContext
    {
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<User> Users { get; set; }

        public UserManagmentContext(DbContextOptions<UserManagmentContext> options) : base(options)
        {
        }

        public UserManagmentContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=WAIANGDESK13\MSSQLSERVER01;Initial Catalog=UserManagment;Integrated Security=True;Trust Server Certificate=True;Command Timeout=300");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.FirstName).IsUnicode(false);

                entity.Property(e => e.Gender)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LastName).IsUnicode(false);

                entity.Property(e => e.MobileNumber).IsUnicode(false);

                entity.Property(e => e.Pan)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.DepartmentRefNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.DepartmentRef)
                    .HasConstraintName("FK_Users_Department");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
