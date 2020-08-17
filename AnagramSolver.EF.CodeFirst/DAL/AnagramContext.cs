using AnagramSolver.Models;
using Microsoft.EntityFrameworkCore;

namespace AnagramSolver.DAL
{
    public class AnagramContext : DbContext
    {
        public AnagramContext(string connString): base(new DbContextOptionsBuilder<AnagramContext>().UseSqlServer(connString).Options)
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