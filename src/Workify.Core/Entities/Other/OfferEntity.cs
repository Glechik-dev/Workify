using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Workify.Core.Entities.Other
{
    public class OfferEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public int Sallary { get; set; }

        public string Currency { get; set; }

        public Guid VacancyId { get; set; }
        [ForeignKey(nameof(VacancyId))]
        public VacancyEntity Vacancy { get; set; }
    }
}
