using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Control.Models
{
    public partial class ControlContext : DbContext
    {
        public ControlContext()
        {
        }

        public ControlContext(DbContextOptions<ControlContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Enrollee> Enrollees { get; set; }
        public virtual DbSet<Specialty> Specialties { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //DESKTOP-2SA8HFU laptop
                //DESKTOP - K8G7B75 PC
                optionsBuilder.UseSqlServer("Server=DESKTOP-K8G7B75;Database=Control;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Enrollee>(entity =>
            {
                entity.ToTable("Enrollee");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address).IsRequired();

                entity.Property(e => e.Birthday).HasColumnType("date");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Specialty)
                    .WithMany(p => p.Enrollees)
                    .HasForeignKey(d => d.SpecialtyId)
                    .HasConstraintName("FK_Enrollee_Specialty");
            });

            modelBuilder.Entity<Specialty>(entity =>
            {
                entity.ToTable("Specialty");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.PeriodOfStudy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Period_of_study");

                entity.Property(e => e.Plan)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Short)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
