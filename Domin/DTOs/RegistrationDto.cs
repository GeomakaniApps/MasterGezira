using DataLayer.Helpers;

namespace Domain.DTOs
{
    public class RegistrationDto : Entity
    {
        public string Email { get; set; } = string.Empty;  
        public string Name { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string? SafeNum { get; set; }
    }
}
