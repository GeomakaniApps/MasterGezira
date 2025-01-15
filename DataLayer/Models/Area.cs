using DataLayer.Helpers;
using System.ComponentModel;

namespace DataLayer.Models;

public class Area:Entity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int? CreateBy { get; set; }
    public DateTime? CreateAt { get; set; }
    public int? UpdateBy { get; set; }
    public DateTime? UpdateAt { get; set; }
    public int? DeleteBy { get; set; }
    public DateTime? DeleteAt { get; set; }
    [DefaultValue(false)]
    public bool IsDeleted { get; set; }
}
