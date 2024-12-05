using DataLayer.Helpers;
using Domain.Common;

namespace Domain.DTOs;

public class UserDto : Entity
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public string Token { get; set; }
}

public class UserResult : OperationResult
{
    public UserDto User { get; set; }
}
