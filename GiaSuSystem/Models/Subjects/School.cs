using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GiaSuSystem.Models.Subjects
{
    public class School
    {
        [Key]
        public int SchoolID { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string SchoolName { get; set; }
        [Required]
        [ForeignKey("CityID")]
        public int City { get; set; }
        [Required]
        [ForeignKey("DistrictID")]
        public int District { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string SchoolAddress { get; set; }
        public string SchoolLogo { get; set; }
    }
}
