using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GiaSuSystem.Models.EducationSystem
{
    public class StudyGroup
    {
        [Key]
        public int StudyGroupID { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string StudyGroupName { get; set; }
        public string StudyGroupImage { get; set; }
        public string TitleColor { get; set; }
    }
}
