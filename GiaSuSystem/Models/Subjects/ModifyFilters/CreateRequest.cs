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
        public LocationInfo Location { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public School SchoolSubject { get; set; }
    }
}
