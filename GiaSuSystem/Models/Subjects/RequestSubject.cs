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
        [Key]
        public int RequestID { get; set; }
        [Required]
        public Subject Subject { get; set; }
        public virtual ICollection<UserModelRequestSubject> Students { get; set; }
        [Required]
        public decimal Price { get; set; }
        public UserModel Owner { get; set; }
        [Required]
        public DateTime RequestDate { get; set; }
        [Required]
        public string LearningAddress { get; set; }
        [Required]
        public string LearningDistrict { get; set; }
        [Required]
        public string LearningCity { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        [Required]
        public string Description { get; set; }
        [Required]
        [ForeignKey("SchoolID")]
        public int SchoolSubject { get; set; }
    }
}
