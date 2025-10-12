using System.ComponentModel.DataAnnotations;

namespace Workify.Core.Entities
{
    public class UserEntitiy
    {

        private UserEntitiy(string fullName, string phoneNumber, string email, string password) 
        {
            Id = Guid.NewGuid();
            FullName = fullName;
            PhoneNumber = phoneNumber;
            Email = email;
            Password = password;
        }
        [Key]
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
        public UserSettingsEntitiy UserSettings { get; private set; }

        public static UserEntitiy Create(string fullName, string phoneNubmer, string email, string password)
        {
            return new UserEntitiy(fullName, phoneNubmer, email, password);
        }
    }
}
