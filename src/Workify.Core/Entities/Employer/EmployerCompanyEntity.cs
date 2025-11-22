using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

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
        int EmploeeNumber {  get; set; }

        public Guid EmployerId { get; set; }
        public EmployerEntity Employer { get; set; }

    }
}
