﻿// <auto-generated />
using System;
using GiaSuSystem.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GiaSuSystem.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20200609024815_Version 1.0.2")]
    partial class Version102
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GiaSuSystem.Models.AppMaintance.FeedbackHub", b =>
                {
                    b.Property<int>("IssueID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Detail")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<int?>("OwnerId")
                        .HasColumnType("int");

                    b.Property<string>("Platform")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TimeUpload")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("IssueID");

                    b.HasIndex("OwnerId");

                    b.ToTable("FeedbackHubs");
                });

            modelBuilder.Entity("GiaSuSystem.Models.EducationSystem.StudyField", b =>
                {
                    b.Property<int>("StudyFieldID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("StudyFieldName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("StudyGroupID")
                        .HasColumnType("int");

                    b.HasKey("StudyFieldID");

                    b.ToTable("StudyFields");
                });

            modelBuilder.Entity("GiaSuSystem.Models.EducationSystem.StudyGroup", b =>
                {
                    b.Property<int>("StudyGroupID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("StudyGroupImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudyGroupName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TitleColor")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudyGroupID");

                    b.ToTable("StudyGroups");
                });

            modelBuilder.Entity("GiaSuSystem.Models.Location.LocationInfo", b =>
                {
                    b.Property<int>("LocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("City")
                        .HasColumnType("int");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)");

                    b.Property<int?>("OwnerId")
                        .HasColumnType("int");

                    b.Property<byte>("Rating")
                        .HasColumnType("tinyint");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("LocationId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("GiaSuSystem.Models.Location.Menu.Drink", b =>
                {
                    b.Property<int>("DrinkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DrinkName")
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("DrinkPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("LocationInfoLocationId")
                        .HasColumnType("int");

                    b.Property<byte>("Rating")
                        .HasColumnType("tinyint");

                    b.Property<string>("Visualize")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DrinkId");

                    b.HasIndex("LocationInfoLocationId");

                    b.ToTable("Drinks");
                });

            modelBuilder.Entity("GiaSuSystem.Models.Location.Menu.Food", b =>
                {
                    b.Property<int>("FoodId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("LocationInfoLocationId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<byte>("Rating")
                        .HasColumnType("tinyint");

                    b.Property<string>("Visualize")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FoodId");

                    b.HasIndex("LocationInfoLocationId");

                    b.ToTable("Foods");
                });

            modelBuilder.Entity("GiaSuSystem.Models.Location.VietNam.City", b =>
                {
                    b.Property<int>("CityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CityID");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("GiaSuSystem.Models.Location.VietNam.District", b =>
                {
                    b.Property<int>("DistrictID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CityID")
                        .HasColumnType("int");

                    b.Property<string>("DistrictName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("DistrictID");

                    b.ToTable("Districts");
                });

            modelBuilder.Entity("GiaSuSystem.Models.MMTables.UserModelRequestSubject", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RequestId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RequestId");

                    b.HasIndex("RequestId");

                    b.ToTable("UserModelRequestSubjects");
                });

            modelBuilder.Entity("GiaSuSystem.Models.Media.LocationImage", b =>
                {
                    b.Property<int>("ImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AzurePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LocationInfoLocationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UploadDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ImageId");

                    b.HasIndex("LocationInfoLocationId");

                    b.ToTable("LocationImages");
                });

            modelBuilder.Entity("GiaSuSystem.Models.Subjects.RequestSubject", b =>
                {
                    b.Property<int>("RequestID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("HomeWork")
                        .HasColumnType("bit");

                    b.Property<bool>("Laboratory")
                        .HasColumnType("bit");

                    b.Property<string>("LearningAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LearningCity")
                        .HasColumnType("int");

                    b.Property<int>("LearningDistrict")
                        .HasColumnType("int");

                    b.Property<int?>("OwnerId")
                        .HasColumnType("int");

                    b.Property<bool>("Presentation")
                        .HasColumnType("bit");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("RequestDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("SubjectID")
                        .HasColumnType("int");

                    b.HasKey("RequestID");

                    b.HasIndex("OwnerId");

                    b.HasIndex("SubjectID");

                    b.ToTable("RequestSubjects");
                });

            modelBuilder.Entity("GiaSuSystem.Models.Subjects.RequestSubjectSchedule", b =>
                {
                    b.Property<int>("ScheduleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("RequestSubjectRequestID")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("TimeEnd")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("TimeStart")
                        .HasColumnType("time");

                    b.Property<string>("WeekDay")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ScheduleID");

                    b.HasIndex("RequestSubjectRequestID");

                    b.ToTable("RequestSubjectSchedules");
                });

            modelBuilder.Entity("GiaSuSystem.Models.Subjects.School", b =>
                {
                    b.Property<int>("SchoolID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("City")
                        .HasColumnType("int");

                    b.Property<int>("District")
                        .HasColumnType("int");

                    b.Property<string>("SchoolAddress")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("SchoolLogo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SchoolName")
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("SchoolID");

                    b.ToTable("Schools");
                });

            modelBuilder.Entity("GiaSuSystem.Models.Subjects.Subject", b =>
                {
                    b.Property<int>("SubjectID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("SchoolID")
                        .HasColumnType("int");

                    b.Property<int>("StudyFieldID")
                        .HasColumnType("int");

                    b.Property<int>("StudyGroupID")
                        .HasColumnType("int");

                    b.Property<string>("Teacher")
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("SubjectID");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("GiaSuSystem.Models.User.UserModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<byte>("Age")
                        .HasColumnType("tinyint");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CoverImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DayOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)");

                    b.Property<bool>("Gender")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("ProfileImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SchoolID")
                        .HasColumnType("int");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StudyFieldID")
                        .HasColumnType("int");

                    b.Property<int>("StudyGroupID")
                        .HasColumnType("int");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("UserCity")
                        .HasColumnType("int");

                    b.Property<int>("UserDistrict")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("GiaSuSystem.Models.AppMaintance.FeedbackHub", b =>
                {
                    b.HasOne("GiaSuSystem.Models.User.UserModel", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId");
                });

            modelBuilder.Entity("GiaSuSystem.Models.Location.LocationInfo", b =>
                {
                    b.HasOne("GiaSuSystem.Models.User.UserModel", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId");
                });

            modelBuilder.Entity("GiaSuSystem.Models.Location.Menu.Drink", b =>
                {
                    b.HasOne("GiaSuSystem.Models.Location.LocationInfo", null)
                        .WithMany("Drinks")
                        .HasForeignKey("LocationInfoLocationId");
                });

            modelBuilder.Entity("GiaSuSystem.Models.Location.Menu.Food", b =>
                {
                    b.HasOne("GiaSuSystem.Models.Location.LocationInfo", null)
                        .WithMany("Foods")
                        .HasForeignKey("LocationInfoLocationId");
                });

            modelBuilder.Entity("GiaSuSystem.Models.MMTables.UserModelRequestSubject", b =>
                {
                    b.HasOne("GiaSuSystem.Models.Subjects.RequestSubject", "Request")
                        .WithMany("Students")
                        .HasForeignKey("RequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GiaSuSystem.Models.User.UserModel", "User")
                        .WithMany("UserSubjectRequests")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GiaSuSystem.Models.Media.LocationImage", b =>
                {
                    b.HasOne("GiaSuSystem.Models.Location.LocationInfo", null)
                        .WithMany("ImagePaths")
                        .HasForeignKey("LocationInfoLocationId");
                });

            modelBuilder.Entity("GiaSuSystem.Models.Subjects.RequestSubject", b =>
                {
                    b.HasOne("GiaSuSystem.Models.User.UserModel", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId");

                    b.HasOne("GiaSuSystem.Models.Subjects.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GiaSuSystem.Models.Subjects.RequestSubjectSchedule", b =>
                {
                    b.HasOne("GiaSuSystem.Models.Subjects.RequestSubject", null)
                        .WithMany("RequestSchedules")
                        .HasForeignKey("RequestSubjectRequestID");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("GiaSuSystem.Models.User.UserModel", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("GiaSuSystem.Models.User.UserModel", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GiaSuSystem.Models.User.UserModel", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("GiaSuSystem.Models.User.UserModel", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
