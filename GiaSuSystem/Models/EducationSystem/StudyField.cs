using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GiaSuSystem.Models.EducationSystem
{
    public class StudyField
    {
        [Key]
        public int StudyFieldID { get; set; }
        [Required]
        [ForeignKey("StudyGroupID")]
        public int StudyGroupID { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string StudyFieldName { get; set; }
    }
}
