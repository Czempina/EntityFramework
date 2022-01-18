using LekcjeCSharp.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LekcjeCSharp.Contexts
{
    public class LekcjeCSharpContext : DbContext
    {
        public virtual DbSet<Student> students { get; set; }
        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Students;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            dbContextOptionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(s => s.Id);
                entity.Property(s => s.CreatedOn);
                entity.Property(s => s.Age);
                entity.Property(s => s.Name);
                entity.Property(s => s.SecondName);
                entity.Property(s => s.ClassesId);
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.HasKey(s => s.Id);
                entity.Property(s => s.CreatedOn);
                entity.Property(s => s.Name);
                entity.Property(s => s.TeachersId);
                entity.HasOne(s => s.Teacher).WithMany().HasForeignKey(s => s.TeachersId);
                entity.HasMany(s => s.Students).WithOne(s => s.Class).HasForeignKey(s => s.ClassesId);
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.HasKey(s => s.Id);
                entity.Property(s => s.CreatedOn);
                entity.Property(s => s.MainSubject);
            });
        }
    }
}
