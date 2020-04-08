using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GiaSuSystem.Models.Media
{
    public class LocationImage
    {
        [Key]
        public int ImageId { get; set; }
        public string AzurePath { get; set; }
        public DateTime UploadDate { get; set; }
    }
}
