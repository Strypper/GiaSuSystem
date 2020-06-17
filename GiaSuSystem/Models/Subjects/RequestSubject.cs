using GiaSuSystem.Models.User;
using GiaSuSystem.Models.Location;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using GiaSuSystem.Models.MMTables;

namespace GiaSuSystem.Models.Subjects
{
    public class RequestSubject
    {
        public enum PayMentTimes
        {
            Hour,
            Week,
            Month
        }
        [Key]
        public int RequestID { get; set; }
        [Required]
        public Subject Subject { get; set; }
        public virtual ICollection<UserModelRequestSubject> Students { get; set; }
        public virtual ICollection<RequestSubjectSchedule> RequestSchedules { get; set; }
        [Required]
        public decimal Price { get; set; }
        public UserModel Owner { get; set; }
        [Required]
        public DateTime RequestDate { get; set; }
        [Required]
        public string LearningAddress { get; set; }
        [Required]
        [ForeignKey("DistrictID")]
        public int LearningDistrict { get; set; }
        [Required]
        [ForeignKey("CityID")]
        public int LearningCity { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        [Required]
        public string Description { get; set; }
        [Column(TypeName = "bit")]
        public bool HomeWork { get; set; }
        [Column(TypeName = "bit")]
        public bool Presentation { get; set; }
        [Column(TypeName = "bit")]
        public bool Laboratory { get; set; }
        public PayMentTimes PayMentTime { get; set; }
    }
}
