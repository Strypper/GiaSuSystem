using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GiaSuSystem.Models.Location.VietNam
{
    public class District
    {
        [Key]
        public int DistrictID { get; set; }
        [Required]
        [ForeignKey("CityID")]
        public int CityID { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string DistrictName { get; set; }
    }
}
