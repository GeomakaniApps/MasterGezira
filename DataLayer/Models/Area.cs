using DataLayer.Helpers;

namespace DataLayer.Models;

public class Area:Entity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
