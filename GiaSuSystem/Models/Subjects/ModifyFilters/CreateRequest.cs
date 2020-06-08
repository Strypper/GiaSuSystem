using GiaSuSystem.Models.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiaSuSystem.Models.Subjects.ModifyFilters
{
    public class CreateRequest
    {
        public string SubjectName { get; set; }
        public string SubjectTeacher { get; set; }
        public int StudyGroup { get; set; }
        public int StudyField { get; set; }
        public string LearningAddress { get; set; }
        public int LearningDistrict { get; set; }
        public int LearningCity { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int? SchoolID { get; set; }
        public string SchoolName { get; set; }
        public int SchoolCity { get; set; }
        public int SchoolDistrict { get; set; }
        public string SchoolAddress { get; set; }
        public string SchoolLogo { get; set; }
        public bool HomeWork { get; set; }
        public bool Presentation { get; set; }
        public bool Laboratory { get; set; }
        public ICollection<RequestSubjectSchedule> WeekDays { get; set; }
    }
}
