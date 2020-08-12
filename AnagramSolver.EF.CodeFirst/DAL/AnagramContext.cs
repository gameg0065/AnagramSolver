using AnagramSolver.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;

namespace AnagramSolver.DAL
{
    public class AnagramContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public AnagramContext(Microsoft.EntityFrameworkCore.DbContextOptions<AnagramContext> options): base(options)
        {
        }

        public DbSet<WordEntity> WordEntities { get; set; }
        public DbSet<UserLogEntity> UserLogEntities { get; set; }
        public DbSet<CachedWordEntity> CachedWordEntities { get; set; }

        protected void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WordEntity>().ToTable("WordEntities");
            modelBuilder.Entity<UserLogEntity>().ToTable("UserLogEntities");
            modelBuilder.Entity<CachedWordEntity>().ToTable("CachedWordEntities");
        }
    }
}