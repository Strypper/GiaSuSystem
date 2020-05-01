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
        public string District { get; set; }
        public string City { get; set; }
        public string SchoolName { get; set; }
        public string SchoolCity { get; set; }
        public string SchoolDistrict { get; set; }
        public string SchoolAddress { get; set; }
        public string ProfileImageUrl { get; set; }
        public Department Department { get; set; }
        public string Pass { get; set; }
        public int SchoolID { get; set; }
    }
}
