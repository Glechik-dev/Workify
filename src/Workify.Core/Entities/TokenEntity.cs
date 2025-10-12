using System.ComponentModel.DataAnnotations;


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
        public Guid Id { get; private set; }
        [Required]
        public string RefreshToken { get; private set; }
        public Guid UserId { get; private set; }
        [Required]
        public UserEntitiy User {  get; private set; }


        public static TokenEntity Create(string refreshToken)
        {
            return new TokenEntity(refreshToken);
        }
    }
}
