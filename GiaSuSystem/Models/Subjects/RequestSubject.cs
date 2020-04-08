using GiaSuSystem.Models.User;
using GiaSuSystem.Models.Location;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace GiaSuSystem.Models.Subjects
{
    public class RequestSubject
    {
        [Key]
        public int RequestID { get; set; }
        public Subject Subject { get; set; }
        public ICollection<UserModel> Students { get; set; }
        public decimal Price { get; set; }
        public UserModel Owner { get; set; }
        public DateTime RequestDate { get; set; }
        public LocationInfo LocationAddress { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string Description { get; set; }
        public School School { get; set; }
    }
}
