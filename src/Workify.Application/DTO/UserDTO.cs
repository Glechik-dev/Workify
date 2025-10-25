

namespace Workify.Application.DTO
{
    public class UserDTO : LoginDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public ICollection<string>? Role { get; set; }
    }
}
