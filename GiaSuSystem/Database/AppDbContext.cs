using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GiaSuSystem.Models.User;
using Microsoft.EntityFrameworkCore;
using GiaSuSystem.Models.Location.Menu;
using GiaSuSystem.Models.Subjects;
using GiaSuSystem.Models.Location;
using GiaSuSystem.Models.Media;
using GiaSuSystem.Models.MMTables;
using Microsoft.AspNetCore.Identity;
using GiaSuSystem.Models.EducationSystem;
using GiaSuSystem.Models.Location.VietNam;

namespace GiaSuSystem.Database
{
    public class AppDbContext : IdentityDbContext<UserModel, IdentityRole<int>, int>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        //Menu
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Food> Foods { get; set; }
        //Subject
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<RequestSubject> RequestSubjects { get; set; }
        //Location
        public DbSet<City> Cities { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<LocationInfo> Locations { get; set; }
        public DbSet<LocationImage> LocationImages { get; set; }

        //University System
        public DbSet<StudyGroup> StudyGroups { get; set; }
        public DbSet<StudyField> StudyFields { get; set; }

        public DbSet<School> Schools { get; set; }

        public DbSet<RequestSubjectSchedule> RequestSubjectSchedules { get; set; }
        //Many to Many Relationship
        public DbSet<UserModelRequestSubject> UserModelRequestSubjects { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            
            base.OnModelCreating(builder);

            builder.Entity<UserModelRequestSubject>()
                   .HasKey(ur => new { ur.UserId, ur.RequestId });

            builder.Entity<UserModelRequestSubject>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserSubjectRequests)
                .HasForeignKey(ur => ur.UserId);


            builder.Entity<UserModelRequestSubject>()
                .HasOne(ur => ur.Request)
                .WithMany(r => r.Students)
                .HasForeignKey(ur => ur.RequestId);
        }
    }
}
