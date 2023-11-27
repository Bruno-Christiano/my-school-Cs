namespace MySchool.DTOs.UserDTO;

public class UserCreateDto
{
    public required string  UserName { get; set; }
    public required string Password { get; set; }
    public string? Email { get; set; }
    public required string Role { get; set; }
}