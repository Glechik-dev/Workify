using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Workify.Core.Entities.Employer;
using Workify.Core.Entities.JobSeeker;

namespace Workify.Core.Entities.Other
{
    public class ResumeEntity
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }


        [Required]
        public string Description { get; set; }

        [Required]
        public string Text { get; set; } 

        [NotMapped]
        public int LikeCount => WhoLikes.Count;
        public ICollection<EmployerEntity> WhoLikes { get; set; } = new List<EmployerEntity>();

        [NotMapped]
        public int DislikeCount => WhoDislikes.Count;

        public ICollection<EmployerEntity> WhoDislikes { get; set; } = new List<EmployerEntity>();

        [Required]
        public Guid AuthorId { get; set; }

        [Required]
        [ForeignKey(nameof(AuthorId))]
        public JobSeekerEntity Author { get; set; }

        [Required]
        public string PhoneNumber {  get; set; }

        [Required]
        public string City {  get; set; }

        [Required]
        public string Age { get; set; }



    }
}
