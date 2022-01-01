using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Migration.Models
{
    public partial class CVManagerContext : DbContext
    {
        public CVManagerContext()
        {
        }

        public CVManagerContext(DbContextOptions<CVManagerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cv> Cvs { get; set; }
        public virtual DbSet<ExperienceInformation> ExperienceInformations { get; set; }
        public virtual DbSet<PersonalInformation> PersonalInformations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=msbs-jehadh;Database=CVManager;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cv>(entity =>
            {
                entity.ToTable("CV");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(d => d.ExperinceInformation)
                    .WithMany(p => p.Cvs)
                    .HasForeignKey(d => d.ExperinceInformationId)
                    .HasConstraintName("FK_CV_ExperienceInformation");

                entity.HasOne(d => d.PersonalInformation)
                    .WithMany(p => p.Cvs)
                    .HasForeignKey(d => d.PersonalInformationId)
                    .HasConstraintName("FK_CV_PersonalInformation");
            });

            modelBuilder.Entity<ExperienceInformation>(entity =>
            {
                entity.ToTable("ExperienceInformation");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CompanyName).HasMaxLength(20);
            });

            modelBuilder.Entity<PersonalInformation>(entity =>
            {
                entity.ToTable("PersonalInformation");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.FullName).IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
