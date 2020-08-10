using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AnagramSolver.EF.DatabaseFirst.Models
{
    public partial class anagramsolverContext : DbContext
    {
        public anagramsolverContext()
        {
        }

        public anagramsolverContext(DbContextOptions<anagramsolverContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CachedWord> CachedWord { get; set; }
        public virtual DbSet<UserLog> UserLog { get; set; }
        public virtual DbSet<Word> Word { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;DataBase=anagramsolver;User ID=sa;Password=LAMA55lama;MultipleActiveResultSets=False;TrustServerCertificate=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CachedWord>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.AnagramId).HasColumnName("anagramId");

                entity.Property(e => e.SearchWord)
                    .IsRequired()
                    .HasColumnName("searchWord")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<UserLog>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Anagram)
                    .IsRequired()
                    .HasColumnName("anagram")
                    .HasMaxLength(255);

                entity.Property(e => e.SearchTime)
                    .HasColumnName("searchTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.SearchWord)
                    .IsRequired()
                    .HasColumnName("searchWord")
                    .HasMaxLength(255);

                entity.Property(e => e.UserIp)
                    .IsRequired()
                    .HasColumnName("userIp")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Word>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasColumnName("category")
                    .HasMaxLength(255);

                entity.Property(e => e.Word1)
                    .IsRequired()
                    .HasColumnName("word")
                    .HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
