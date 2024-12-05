using DataLayer.Helpers;

namespace Domain.DTOs;

public class EnumDto : Entity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string DisplayName { get; set; } = string.Empty;
}
