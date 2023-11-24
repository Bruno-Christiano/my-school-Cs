namespace MySchool.Models.User;

public class User
{
    public int Id { get; set; }
    public required string  UserName { get; set; }
    public required string Password { get; set; }
    public string? Email { get; set; }
    public required string Role { get; set; }
}