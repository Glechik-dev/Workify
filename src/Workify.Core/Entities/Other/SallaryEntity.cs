using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Workify.Core.Entities.Other
{
    public class SallaryEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public int Sallary {  get; set; }

        public string Currency {  get; set; }

        public Guid ResumeId { get; set; }
        [ForeignKey(nameof(ResumeId))]
        public ResumeEntity Resume { get; set; }


    }
}
