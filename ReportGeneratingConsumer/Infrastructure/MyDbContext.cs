using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Common.Model;

namespace ReportGeneratingConsumer.Infrastructure
{
    public class MyDbContext : DbContext
    {
        public DbSet<Point> Points { get; set; } // Example DbSet for a User entity

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configure the connection to MySQL
            string connectionString = "Server=localhost;Port=3306;Database=scadatimetravel;Uid=public;Pwd=public;";
            optionsBuilder.UseMySQL(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Point>(entity =>
            {
                entity.ToTable("points"); // Map to the Users table in the database

                entity.HasKey(e => e.PointNumber); // Specify the primary key

                entity.Property(e => e.PointNumber).HasColumnName("POINT_NUMBER");
                entity.Property(e => e.Element).HasColumnName("ELEMENT");
                entity.Property(e => e.PointType).HasColumnName("POINT_TYPE");
                entity.Property(e => e.LastModified).HasColumnName("LAST_MODIFIED");
                entity.Property(e => e.Active).HasColumnName("ACTIVE");

            });
        }
    }
}



