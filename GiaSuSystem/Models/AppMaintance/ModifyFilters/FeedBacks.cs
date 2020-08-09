using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiaSuSystem.Models.AppMaintance.ModifyFilters
{
    public class FeedBacks
    {
        public int FeedBackId { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Platform { get; set; }
        public DateTime TimeUpload { get; set; }
    }
}
