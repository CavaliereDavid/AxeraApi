﻿// <auto-generated />
using System;
using AxeraApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AxeraApi.Migrations
{
    [DbContext(typeof(AxeraDbContext))]
    [Migration("20231025135707_Seeding data")]
    partial class Seedingdata
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AxeraApi.Domain.Models.Course", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Course");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a0203c2f-16d5-4f87-bc6f-6a1a4eb67002"),
                            Description = "Learn the basics of programming with this introductory course.",
                            IsDeleted = false,
                            Name = "Introduction to Programming"
                        },
                        new
                        {
                            Id = new Guid("bc103b57-4e13-4ff8-9a18-2158d0ec41dd"),
                            Description = "Explore the fundamentals of web development.",
                            IsDeleted = false,
                            Name = "Web Development Fundamentals"
                        },
                        new
                        {
                            Id = new Guid("ff1e8442-ff9b-4c19-9865-c77ad810c609"),
                            Description = "Master the essentials of data science and analysis.",
                            IsDeleted = false,
                            Name = "Data Science Essentials"
                        },
                        new
                        {
                            Id = new Guid("5c56b3f3-1fb2-4f99-80db-8ea2bbcdfe25"),
                            Description = "Create mobile apps for both Android and iOS platforms.",
                            IsDeleted = false,
                            Name = "Mobile App Development"
                        });
                });

            modelBuilder.Entity("AxeraApi.Domain.Models.Meeting", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CourseID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("MaxUsers")
                        .HasColumnType("int");

                    b.Property<int>("MinUsers")
                        .HasColumnType("int");

                    b.Property<string>("Note")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<DateTime>("ScheduledMeeting")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CourseID");

                    b.ToTable("Meeting");

                    b.HasData(
                        new
                        {
                            Id = new Guid("9a18e6f1-0343-4a0a-845e-86524cc95e67"),
                            CourseID = new Guid("a0203c2f-16d5-4f87-bc6f-6a1a4eb67002"),
                            Duration = 90,
                            IsDeleted = false,
                            MaxUsers = 20,
                            MinUsers = 5,
                            Note = "Introduction to Programming",
                            ScheduledMeeting = new DateTime(2023, 11, 1, 13, 57, 7, 274, DateTimeKind.Utc).AddTicks(9816)
                        },
                        new
                        {
                            Id = new Guid("f674b6e3-7e3d-4b7c-8ff4-0a66a39bb14b"),
                            CourseID = new Guid("bc103b57-4e13-4ff8-9a18-2158d0ec41dd"),
                            Duration = 120,
                            IsDeleted = false,
                            MaxUsers = 15,
                            MinUsers = 3,
                            Note = "Web Development Fundamentals",
                            ScheduledMeeting = new DateTime(2023, 11, 8, 13, 57, 7, 274, DateTimeKind.Utc).AddTicks(9827)
                        },
                        new
                        {
                            Id = new Guid("b0841f9d-6d0d-43e6-9429-20d7f3ac0ef7"),
                            CourseID = new Guid("ff1e8442-ff9b-4c19-9865-c77ad810c609"),
                            Duration = 120,
                            IsDeleted = false,
                            MaxUsers = 15,
                            MinUsers = 5,
                            Note = "Data Science Essentials",
                            ScheduledMeeting = new DateTime(2023, 11, 4, 13, 57, 7, 274, DateTimeKind.Utc).AddTicks(9830)
                        },
                        new
                        {
                            Id = new Guid("3f9e262a-1813-47f9-983d-716f053e7d4c"),
                            CourseID = new Guid("5c56b3f3-1fb2-4f99-80db-8ea2bbcdfe25"),
                            Duration = 120,
                            IsDeleted = false,
                            MaxUsers = 20,
                            MinUsers = 5,
                            Note = "Mobile App Development Workshop",
                            ScheduledMeeting = new DateTime(2023, 11, 15, 13, 57, 7, 274, DateTimeKind.Utc).AddTicks(9833)
                        });
                });

            modelBuilder.Entity("AxeraApi.Domain.Models.Reservation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid>("MeetingID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Note")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("VerifiedPayment")
                        .HasColumnType("bit");

                    b.Property<bool?>("Withdraw")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("MeetingID");

                    b.HasIndex("UserID");

                    b.ToTable("Reservation");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8a1e2258-4315-4562-8fc6-a7fb32d147a9"),
                            IsDeleted = false,
                            MeetingID = new Guid("9a18e6f1-0343-4a0a-845e-86524cc95e67"),
                            Note = "Reserved for John Doe",
                            UserID = new Guid("852bb3a4-2d4b-4dbf-aa18-cbe7f3e2f96d"),
                            VerifiedPayment = true,
                            Withdraw = false
                        },
                        new
                        {
                            Id = new Guid("82727523-ab6f-4115-9b73-72e03f0fda8a"),
                            IsDeleted = false,
                            MeetingID = new Guid("f674b6e3-7e3d-4b7c-8ff4-0a66a39bb14b"),
                            Note = "Reserved for Alice Smith",
                            UserID = new Guid("6f59a8e1-7c7e-4c0a-a139-0f423f068f95"),
                            VerifiedPayment = true,
                            Withdraw = false
                        },
                        new
                        {
                            Id = new Guid("0e373944-736f-4c37-958a-d7749c5a75d3"),
                            IsDeleted = false,
                            MeetingID = new Guid("b0841f9d-6d0d-43e6-9429-20d7f3ac0ef7"),
                            Note = "Reserved for Sarah Lee",
                            UserID = new Guid("d4a1ed96-7f9a-41ea-9a87-8f50c9aa50f7"),
                            VerifiedPayment = true,
                            Withdraw = false
                        },
                        new
                        {
                            Id = new Guid("a42e51eb-eeef-4a07-aaac-bf80848f442a"),
                            IsDeleted = false,
                            MeetingID = new Guid("3f9e262a-1813-47f9-983d-716f053e7d4c"),
                            Note = "Reserved for Michael Brown",
                            UserID = new Guid("2c7f6f19-1647-4923-892a-77a6a825b0cf"),
                            VerifiedPayment = true,
                            Withdraw = false
                        });
                });

            modelBuilder.Entity("AxeraApi.Domain.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Allergies")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<bool?>("ConsentToPersonalData")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsNewsletterActive")
                        .HasColumnType("bit");

                    b.Property<string>("ParentFullName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ParticipantFullName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("int");

                    b.Property<bool?>("PrivacyPolicyAcknowledgement")
                        .HasColumnType("bit");

                    b.Property<bool?>("VerifiedUser")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = new Guid("852bb3a4-2d4b-4dbf-aa18-cbe7f3e2f96d"),
                            Age = 30,
                            Allergies = "Peanuts",
                            ConsentToPersonalData = true,
                            Email = "john.doe@email.com",
                            IsDeleted = false,
                            IsNewsletterActive = true,
                            ParentFullName = "Mary Doe",
                            ParticipantFullName = "John Doe",
                            PhoneNumber = 1234567890,
                            PrivacyPolicyAcknowledgement = true,
                            VerifiedUser = true
                        },
                        new
                        {
                            Id = new Guid("6f59a8e1-7c7e-4c0a-a139-0f423f068f95"),
                            Age = 25,
                            Allergies = "None",
                            ConsentToPersonalData = true,
                            Email = "alice.smith@email.com",
                            IsDeleted = false,
                            IsNewsletterActive = false,
                            ParentFullName = "Bob Smith",
                            ParticipantFullName = "Alice Smith",
                            PhoneNumber = 1234567891,
                            PrivacyPolicyAcknowledgement = true,
                            VerifiedUser = true
                        },
                        new
                        {
                            Id = new Guid("d4a1ed96-7f9a-41ea-9a87-8f50c9aa50f7"),
                            Age = 22,
                            Allergies = "Gluten",
                            ConsentToPersonalData = true,
                            Email = "sarah.lee@email.com",
                            IsDeleted = false,
                            IsNewsletterActive = true,
                            ParentFullName = "James Lee",
                            ParticipantFullName = "Sarah Lee",
                            PhoneNumber = 1234567892,
                            PrivacyPolicyAcknowledgement = true,
                            VerifiedUser = true
                        },
                        new
                        {
                            Id = new Guid("2c7f6f19-1647-4923-892a-77a6a825b0cf"),
                            Age = 27,
                            Allergies = "Shellfish",
                            ConsentToPersonalData = true,
                            Email = "michael.brown@email.com",
                            IsDeleted = false,
                            IsNewsletterActive = true,
                            ParentFullName = "Karen Brown",
                            ParticipantFullName = "Michael Brown",
                            PhoneNumber = 1234567893,
                            PrivacyPolicyAcknowledgement = true,
                            VerifiedUser = true
                        });
                });

            modelBuilder.Entity("AxeraApi.Domain.Models.Meeting", b =>
                {
                    b.HasOne("AxeraApi.Domain.Models.Course", "Course")
                        .WithMany("Meetings")
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("AxeraApi.Domain.Models.Reservation", b =>
                {
                    b.HasOne("AxeraApi.Domain.Models.Meeting", "Meeting")
                        .WithMany("Reservations")
                        .HasForeignKey("MeetingID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AxeraApi.Domain.Models.User", "User")
                        .WithMany("Reservations")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Meeting");

                    b.Navigation("User");
                });

            modelBuilder.Entity("AxeraApi.Domain.Models.Course", b =>
                {
                    b.Navigation("Meetings");
                });

            modelBuilder.Entity("AxeraApi.Domain.Models.Meeting", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("AxeraApi.Domain.Models.User", b =>
                {
                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
