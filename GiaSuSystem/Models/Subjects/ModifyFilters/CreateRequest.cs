using GiaSuSystem.Models.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiaSuSystem.Models.Subjects.ModifyFilters
{
    public class CreateRequest
    {
        public Subject Subject { get; set; }
        public string LearningAddress { get; set; }
        public string LearningDistrict { get; set; }
        public string LearningStreet { get; set; }
        public string LearningCity { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int? SchoolID { get; set; }
        public string SchoolName { get; set; }
        public string SchoolCity { get; set; }
        public string SchoolDistrict { get; set; }
        public string SchoolAddress { get; set; }
        public string SchoolLogo { get; set; }
    }
}
