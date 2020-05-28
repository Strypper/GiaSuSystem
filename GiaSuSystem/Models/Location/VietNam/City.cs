using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GiaSuSystem.Models.Location.VietNam
{
    public class City
    {
        public int CityID { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string CityName { get; set; }
    }
}
