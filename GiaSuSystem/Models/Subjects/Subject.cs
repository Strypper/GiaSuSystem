using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GiaSuSystem.Models.Subjects
{
    public class Subject
    {
        [Key]
        public int SubjectID { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }
        public School School { get; set; }
        public Department Department { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Teacher { get; set; }
    }
}
