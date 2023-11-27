namespace MySchool.Models.User;

public class ShowUserDto
{
    public int Id { get; set; }
    public required string  UserName { get; set; }
    
    public required string Password { get; set; }
    public string? Email { get; set; }
    public required string Role { get; set; }

    public ShowUserDto(User user)
    {
        Id = user.Id;
        UserName = user.UserName;
        Email = user.Email;
        Role = user.Role;
    }
}