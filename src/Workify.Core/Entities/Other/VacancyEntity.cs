using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Workify.Core.Entities.Employer;
using Workify.Core.Entities.JobSeeker;

namespace Workify.Core.Entities.Other
{
    public class VacancyEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Text { get; set; }

        [NotMapped]
        public int LikeCount => WhoLikes.Count;
        public ICollection<JobSeekerEntity> WhoLikes { get; set; } = new List<JobSeekerEntity>();

        [NotMapped]
        public int DislikeCount => WhoDislikes.Count;

        public ICollection<JobSeekerEntity> WhoDislikes { get; set; } = new List<JobSeekerEntity>();

        [Required]
        public Guid AuthorId { get; set; }

        [Required]
        [ForeignKey(nameof(AuthorId))]
        public EmployerEntity Author { get; set; }
    }
}
