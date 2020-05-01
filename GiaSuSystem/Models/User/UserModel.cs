using GiaSuSystem.Models.MMTables;
using GiaSuSystem.Models.Subjects;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GiaSuSystem.Models.User
{
    public class UserModel : IdentityUser<int>
    {
        public static object Claims { get; internal set; }
        [NotMapped]
        public string Pass { get; set; }
        [Required]
        public string Role { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(10)")]
        public string FirstName { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(10)")]
        public string LastName { get; set; }
        [Required]
        public string ProfileImageUrl { get; set; }
        public string CoverImageUrl { get; set; }
        [Column(TypeName = "date")]
        public DateTime DayOfBirth { get; set; }
        [Column(TypeName = "bit")]
        public bool Gender { get; set; }
        [Required]
        [Range(18, 60, ErrorMessage = "Your Age Must Older Than 18")]
        [Column(TypeName = "tinyint")]
        public int Age { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string UserAddress { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string UserCity { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string UserDistrict { get; set; }
        public Department Department { get; set; }
        public virtual ICollection<UserModelRequestSubject> UserSubjectRequests { get; set; }
        [ForeignKey("SchoolID")]
        public int SchoolID { get; set; }
    }
}
