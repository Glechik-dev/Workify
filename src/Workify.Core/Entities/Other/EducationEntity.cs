using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Workify.Core.Entities.Other
{
    public class EducationEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public string SpecialityName { get; set; }

        [Required]
        public string EstablishmentName { get; set; }

        public string EndDate { get; set; }

        public string Country { get; set; }

        public Guid ResumeId { get; set; }

        [ForeignKey(nameof(ResumeId))]
        public ResumeEntity Resume { get; set; }
    }
}
