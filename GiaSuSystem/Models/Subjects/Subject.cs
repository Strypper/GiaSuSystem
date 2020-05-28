using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GiaSuSystem.Models.Subjects
{
    public class Subject
    {
        [Key]
        public int SubjectID { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }
        [Required]
        [ForeignKey("SchoolID")]
        public int SchoolID { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Teacher { get; set; }
        [Required]
        [ForeignKey("StudyGroupID")]
        public int StudyGroupID { get; set; }
        [Required]
        [ForeignKey("StudyFieldID")]
        public int StudyFieldID { get; set; }
    }
}
