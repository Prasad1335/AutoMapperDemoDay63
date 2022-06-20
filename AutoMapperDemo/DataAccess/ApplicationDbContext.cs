using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using AutoMapperDemo.Data.Models;

namespace AutoMapperDemo.DataAccess
{
    public partial class ApplicationDbContext : DbContext
    {
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<User> Users { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=WAIANGDESK13\MSSQLSERVER01;Initial Catalog=UserManagment;Integrated Security=True;Trust Server Certificate=True;Command Timeout=300");
            }
        }

    
    }
}
