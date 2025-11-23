using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Workify.Core.Entities.Other
{
    public class CourseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public string SpecialityName { get; set; }

        [Required]
        public string EndDate { get; set; }

        public Guid ResumeId { get; set; }

        [ForeignKey(nameof(ResumeId))]
        public ResumeEntity Resume { get; set; }
    }
}
