using System.ComponentModel.DataAnnotations;

namespace Workify.Api.Contracts
{
    public class ResumeContract
    {
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Description { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public int Age { get; set; }
    }
}
