using GiaSuSystem.Models.Location.Menu;
using GiaSuSystem.Models.Media;
using GiaSuSystem.Models.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GiaSuSystem.Models.Location
{
    public class LocationInfo
    {
        [Key]
        public int LocationId { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Address { get; set; }
        [Required]
        [ForeignKey("CityID")]
        public int City { get; set; }
        [Column(TypeName = "nvarchar(40)")]
        [Required]
        [ForeignKey("DistrictID")]
        public int District { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Street { get; set; }
        public virtual ICollection<LocationImage> ImagePaths { get; set; }
        public UserModel Owner { get; set; }
        public ServiceType Type { get; set; }
        public virtual ICollection<Food> Foods { get; set; }
        public virtual ICollection<Drink> Drinks { get; set; }
        [Column(TypeName = "tinyint")]
        public int Rating { get; set; }
    }
}
