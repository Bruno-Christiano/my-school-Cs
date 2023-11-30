

using System;
using System.Linq;
using MySchool.Data;
using Newtonsoft.Json;


namespace MySchool.Services.Auth;

public class AuthService
{
    private readonly ApplicationDbContext  _dbContext;
    
    public AuthService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public bool AuthenticateUser(string userName, string password)
    {
        // Verificar se o usuário existe na tabela
        var user = _dbContext.Users.FirstOrDefault(u => u.UserName == userName);

        if (user != null)
        {
            return VerifyPassword(password, user.Password);
        }

        return false;
        
    }
 
    public bool VerifyPassword(string enteredPassword, string hashedPasswordFromDatabase)
    {
       
        return BCrypt.Net.BCrypt.Verify(enteredPassword, hashedPasswordFromDatabase);
    }
}