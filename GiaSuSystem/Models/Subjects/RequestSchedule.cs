using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GiaSuSystem.Models.Subjects
{
    public class RequestSubjectSchedule
    {
        [Key]
        public int ScheduleID { get; set; }
        [Required]
        public string WeekDay { get; set; }
        [Column(TypeName = "time")]
        public TimeSpan TimeStart { get; set; }
        [Column(TypeName = "time")]
        public TimeSpan TimeEnd { get; set; }
    }
}
