using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Workify.Core.Entities
{
    public class UserEntity
    {

        private UserEntity(string fullName, string phoneNumber, string email, string password) 
        {
            Id = Guid.NewGuid();
            FullName = fullName;
            PhoneNumber = phoneNumber;
            Email = email;
            Password = password;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; private set; }
        [Required]
        public string FullName { get; private set; }
        [Required]
        public string PhoneNumber { get; private set; }
        [Required]
        public string Email { get; private set; }
        [Required]
        public string Password { get; private set; }
        [Required]
        public TokenEntity Token { get; private set; }
        [Required]
        public UserSettingsEntity UserSettings { get; private set; }

        public static UserEntity Create(string fullName, string phoneNubmer, string email, string password)
        {
            return new UserEntity(fullName, phoneNubmer, email, password);
        }
    }
}
