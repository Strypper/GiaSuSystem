using GiaSuSystem.Models.User;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GiaSuSystem.Models.AppMaintance
{
    public class FeedbackHub
    {
        [Key]
        public int IssueID { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(60)")]
        public string Title { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Detail { get; set; }
        [Required]
        public string Platform { get; set; }
        public UserModel Owner { get; set; }
        public DateTime TimeUpload { get; set; }
    }
}
