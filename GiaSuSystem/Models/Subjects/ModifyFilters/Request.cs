using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiaSuSystem.Models.Subjects.ModifyFilters
{
     public class RequestPage
    {
         public int RequestID { get; set; }
         public string ProfileUrlImage { get; set; }
         public string Firstname { get; set; }
         public string Lastname { get; set; }
         public decimal Price { get; set; }
         public string Sub { get; set; }
         public School School { get; set; }
         public DateTime Date { get; set; }
    }
}
