using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace XiaoQi.EFCore
{
    public partial class MyContext : DbContext
    {
        public MyContext()
        {
        }

        public MyContext(DbContextOptions<MyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<UserSteps> UserSteps { get; set; }
        public virtual DbSet<Userinfo> Userinfo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
        
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserSteps>(entity =>
            {
                entity.ToTable("user-steps");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .HasColumnName("user-id")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserSteps1)
                    .HasColumnName("user-steps")
                    .HasColumnType("int(255)");
            });

            modelBuilder.Entity<Userinfo>(entity =>
            {
                entity.ToTable("userinfo");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Sex)
                    .HasColumnName("sex")
                    .HasColumnType("int(255)");

                entity.Property(e => e.Userage)
                    .HasColumnName("userage")
                    .HasColumnType("int(20)");

                entity.Property(e => e.Usercount)
                    .HasColumnName("usercount")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Userpassword)
                    .HasColumnName("userpassword")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
