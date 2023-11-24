

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
        var user = _dbContext.Users.FirstOrDefault(u => u.UserName == userName && u.Password == password);

        // Retornar true se o usuário foi encontrado, senão false
        var listUser = JsonConvert.SerializeObject(_dbContext.Users);
        Console.WriteLine($"lista de dados db {listUser}");
        return user != null;
      
    }
}