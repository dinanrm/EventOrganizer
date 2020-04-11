using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using EventOrganizer.Models;

namespace EventOrganizer.Data
{
    public partial class EventOrganizerDbContext : DbContext
    {
        public EventOrganizerDbContext()
        {
        }

        public EventOrganizerDbContext(DbContextOptions<EventOrganizerDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<Organizer> Organizer { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>(entity =>
            {
                entity.ToTable("event");

                entity.HasIndex(e => e.OrganizerId)
                    .HasName("fkIdx_26");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.EndTime).HasColumnName("end_time");

                entity.Property(e => e.HeldDate)
                    .HasColumnName("held_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OrganizerId).HasColumnName("organizer_id");

                entity.Property(e => e.StartTime).HasColumnName("start_time");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Organizer)
                    .WithMany(p => p.Event)
                    .HasForeignKey(d => d.OrganizerId)
                    .HasConstraintName("FK_26");
            });

            modelBuilder.Entity<Organizer>(entity =>
            {
                entity.ToTable("organizer");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.ImageLocation)
                    .HasColumnName("image_location")
                    .HasColumnType("text");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("role");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.HasIndex(e => e.OrganizerId)
                    .HasName("fkIdx_54");

                entity.HasIndex(e => e.RoleId)
                    .HasName("fkIdx_51");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasColumnType("text");

                entity.Property(e => e.Avatar)
                    .HasColumnName("avatar")
                    .HasColumnType("text");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasColumnName("gender")
                    .HasColumnType("text");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.JoinDate)
                    .HasColumnName("join_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.LastLogin)
                    .HasColumnName("last_login")
                    .HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OrganizerId).HasColumnName("organizer_id");

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasColumnName("phone_number")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Organizer)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.OrganizerId)
                    .HasConstraintName("FK_54");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_51");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
