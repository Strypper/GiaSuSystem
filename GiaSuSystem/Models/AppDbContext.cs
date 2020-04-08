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

namespace GiaSuSystem.Models
{
    public class AppDbContext : IdentityDbContext<UserModel>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        //Menu
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Food> Foods { get; set; }
        //Subject
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<RequestSubject> RequestSubjects { get; set; }
        //Location
        public DbSet<LocationInfo> Locations { get; set; }
        public DbSet<LocationImage> LocationImages { get; set; }

        public DbSet<School> Schools { get; set; }
    }
}
