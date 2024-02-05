namespace Domain.Requests;

public class BaseUserRequest
{
    public int UserId {  get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? Role { get; set; }
}

public class UpdateUserRequest : BaseUserRequest
{
    public int Id { get; set; }
}