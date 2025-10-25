
using System.ComponentModel.DataAnnotations;

namespace Workify.Application.DTO
{
    public class RegistrationDTO
    {
        public string FistName { get; set; }
        public string SecondName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
