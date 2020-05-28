using GiaSuSystem.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiaSuSystem.Models.Subjects.ModifyFilters
{
    public class RegisterUser
    {
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public DateTime DayOfBirth { get; set; }
        public bool Gender { get; set; }
        public int Age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public int District { get; set; }
        public int City { get; set; }
        public string SchoolName { get; set; }
        public int SchoolCity { get; set; }
        public int SchoolDistrict { get; set; }
        public string SchoolAddress { get; set; }
        public string ProfileImageUrl { get; set; }
        public string Pass { get; set; }
        public int? SchoolID { get; set; }
        public int StudyGroup { get; set; }
        public int StudyField { get; set; }
    }
}
