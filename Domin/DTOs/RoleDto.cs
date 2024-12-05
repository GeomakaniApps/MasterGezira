using DataLayer.Helpers;
using Domain.Common;
using System.ComponentModel.DataAnnotations;


namespace Domain.DTOs;

public class RoleDto:Entity
{
    public string Role { get; set; }
}
public class RoleResult:OperationResult
{
    public List<RoleDto> RoleDto { get; set; }
}
