using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Workify.Core.Entities.User;


namespace Workify.Core.Entities.Other
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
        public string RefreshToken { get; set; }
        public Guid UserId { get; private set; }
        [Required]
        public UserEntity User { get; private set; }


        public static TokenEntity Create(string refreshToken)
        {
            return new TokenEntity(refreshToken);
        }
    }
}
