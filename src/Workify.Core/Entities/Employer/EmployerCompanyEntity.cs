using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Workify.Core.Entities.Other;

namespace Workify.Core.Entities.Employer
{
    public class EmployerCompanyEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        Guid Id { get; set; }

        [Required]
        string CompanyName { get; set; }

        [Required]
        string Description { get; set; }

        [Required]
        string Company { get; set; }

        [Required]
        string OnMarket {  get; set; }

        [Required]
        int EmploeeNumber {  get; set; }

        public ICollection<VacancyEntity> Vacancies { get; set; } = new List<VacancyEntity>();

        public Guid EmployerId { get; set; }
        public EmployerEntity Employer { get; set; }

        public OurSocialEntity OurSocial { get; set; }

    }
}
