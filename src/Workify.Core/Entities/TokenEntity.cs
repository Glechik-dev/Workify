using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Workify.Core.Entities
{
    public class TokenEntity
    {
        private TokenEntity(string refreshToken) 
        {
            Id = Guid.NewGuid(); ;
            RefreshToken = refreshToken;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; private set; }
        [Required]
        public string RefreshToken { get; private set; }
        public Guid JobSeekerId { get; private set; }
        [Required]
        public JobSeekerEntity JobSeeker {  get; private set; }


        public static TokenEntity Create(string refreshToken)
        {
            return new TokenEntity(refreshToken);
        }
    }
}
