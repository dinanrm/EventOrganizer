﻿// <auto-generated />
using System;
using EventOrganizer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EventOrganizer.Migrations
{
    [DbContext(typeof(EventOrganizerDbContext))]
    [Migration("20200411144605_All-InitialCreate")]
    partial class AllInitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EventOrganizer.Models.Event", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnName("id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnName("created_at")
                        .HasColumnType("datetime");

                    b.Property<TimeSpan?>("EndTime")
                        .HasColumnName("end_time")
                        .HasColumnType("time");

                    b.Property<DateTime?>("HeldDate")
                        .HasColumnName("held_date")
                        .HasColumnType("datetime");

                    b.Property<bool?>("IsActive")
                        .HasColumnName("is_active")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<Guid?>("OrganizerId")
                        .HasColumnName("organizer_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<TimeSpan?>("StartTime")
                        .HasColumnName("start_time")
                        .HasColumnType("time");

                    b.Property<string>("Type")
                        .HasColumnName("type")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnName("updated_at")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("OrganizerId")
                        .HasName("fkIdx_26");

                    b.ToTable("event");
                });

            modelBuilder.Entity("EventOrganizer.Models.Organizer", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnName("id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnName("created_at")
                        .HasColumnType("datetime");

                    b.Property<string>("ImageLocation")
                        .HasColumnName("image_location")
                        .HasColumnType("text");

                    b.Property<bool?>("IsActive")
                        .HasColumnName("is_active")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnName("updated_at")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("organizer");
                });

            modelBuilder.Entity("EventOrganizer.Models.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnName("id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnName("created_at")
                        .HasColumnType("datetime");

                    b.Property<bool?>("IsActive")
                        .HasColumnName("is_active")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnName("updated_at")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("role");
                });

            modelBuilder.Entity("EventOrganizer.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnName("id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnName("address")
                        .HasColumnType("text");

                    b.Property<string>("Avatar")
                        .HasColumnName("avatar")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnName("created_at")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .HasColumnName("email")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Gender")
                        .HasColumnName("gender")
                        .HasColumnType("text");

                    b.Property<bool?>("IsActive")
                        .HasColumnName("is_active")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("JoinDate")
                        .HasColumnName("join_date")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("LastLogin")
                        .HasColumnName("last_login")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<Guid?>("OrganizerId")
                        .HasColumnName("organizer_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Password")
                        .HasColumnName("password")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("PhoneNumber")
                        .HasColumnName("phone_number")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<Guid?>("RoleId")
                        .HasColumnName("role_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnName("updated_at")
                        .HasColumnType("datetime");

                    b.Property<string>("Username")
                        .HasColumnName("username")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.HasIndex("OrganizerId")
                        .HasName("fkIdx_54");

                    b.HasIndex("RoleId")
                        .HasName("fkIdx_51");

                    b.ToTable("user");
                });

            modelBuilder.Entity("EventOrganizer.Models.Event", b =>
                {
                    b.HasOne("EventOrganizer.Models.Organizer", "Organizer")
                        .WithMany("Event")
                        .HasForeignKey("OrganizerId")
                        .HasConstraintName("FK_26");
                });

            modelBuilder.Entity("EventOrganizer.Models.User", b =>
                {
                    b.HasOne("EventOrganizer.Models.Organizer", "Organizer")
                        .WithMany("User")
                        .HasForeignKey("OrganizerId")
                        .HasConstraintName("FK_54");

                    b.HasOne("EventOrganizer.Models.Role", "Role")
                        .WithMany("User")
                        .HasForeignKey("RoleId")
                        .HasConstraintName("FK_51");
                });
#pragma warning restore 612, 618
        }
    }
}