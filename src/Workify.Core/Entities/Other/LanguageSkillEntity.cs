using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Workify.Core.Entities.Other
{
    public class LanguageSkillEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Guid ResumeId { get; set; }
        public ResumeEntity Resume { get; set; }

        public Guid LanguageId { get; set; }
        public LanguageEntity Language { get; set; }

        [Required]
        public string Proficiency { get; set; }
    }
}
