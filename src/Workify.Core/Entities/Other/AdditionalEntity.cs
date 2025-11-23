using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Workify.Core.Entities.Other
{
    public class AdditionalEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid ResumeId { get; set; }

        [ForeignKey(nameof(ResumeId))]
        public ResumeEntity Resume { get; set; }
    }
}
