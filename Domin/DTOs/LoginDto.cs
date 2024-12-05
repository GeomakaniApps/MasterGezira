using DataLayer.Helpers;
using System.ComponentModel.DataAnnotations;


namespace Domain.DTOs;

public class LoginDto : Entity
{
    [Required]
    public string? Email { get; set; }
    [Required]
    public string? Password { get; set; }
}
