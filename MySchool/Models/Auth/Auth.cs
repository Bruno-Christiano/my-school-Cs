using System;

namespace MySchool.Models.Auth;

public class Auth
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    
    public string UserNameError { get; set; }
    public string UserPasswordError { get; set; }
    
}