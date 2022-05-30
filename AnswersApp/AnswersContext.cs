using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AnswersApp
{
    public partial class AnswersContext : DbContext
    {
        public AnswersContext()
        {
        }

        public AnswersContext(DbContextOptions<AnswersContext> options)
            : base(options)
        {
        }

        public virtual DbSet<StatusTask> StatusTasks { get; set; } = null!;
        public virtual DbSet<Task> Tasks { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;DataBase=Answers;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StatusTask>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.Property(e => e.DateOfPublication).HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.IdAcceptedNavigation)
                    .WithMany(p => p.TaskIdAcceptedNavigations)
                    .HasForeignKey(d => d.IdAccepted)
                    .HasConstraintName("FK_Tasks_Users");

                entity.HasOne(d => d.IdCreatorNavigation)
                    .WithMany(p => p.TaskIdCreatorNavigations)
                    .HasForeignKey(d => d.IdCreator)
                    .HasConstraintName("FK_Tasks_Users1");

                entity.HasOne(d => d.IdStatusTaskNavigation)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.IdStatusTask)
                    .HasConstraintName("FK_Tasks_StatusTasks");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .HasColumnName("firstName");

                entity.Property(e => e.Login).HasMaxLength(50);

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(50)
                    .HasColumnName("middleName");

                entity.Property(e => e.NumberPhone)
                    .HasMaxLength(50)
                    .HasColumnName("numberPhone");

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.SecondName)
                    .HasMaxLength(50)
                    .HasColumnName("secondName");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
