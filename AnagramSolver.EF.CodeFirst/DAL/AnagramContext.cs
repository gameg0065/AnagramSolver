using AnagramSolver.Models;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.EntityFrameworkCore;
using System;

namespace AnagramSolver.DAL
{
    public class AnagramContext : DbContext
    {
        public AnagramContext(): base(new DbContextOptionsBuilder<AnagramContext>().UseSqlServer("Server=localhost;Database=anagramsolver; User Id = sa; Password = LAMA55lama").Options)
        {
        }

        public DbSet<WordEntity> WordEntities { get; set; }
        public DbSet<UserLogEntity> UserLogEntities { get; set; }
        public DbSet<CachedWordEntity> CachedWordEntities { get; set; }

        protected void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WordEntity>().ToTable("WordEntities");
            modelBuilder.Entity<UserLogEntity>().ToTable("UserLogEntities");
            modelBuilder.Entity<CachedWordEntity>().ToTable("CachedWordEntities");
        }
    }
}