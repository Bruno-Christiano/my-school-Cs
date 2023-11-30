using System.Threading.Tasks;
using MySchool.Data;

namespace MySchool.Services.User;

public class UserService
{
    private readonly ApplicationDbContext  _dbContext;
    
    public UserService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task<Models.User.User> SaveUser(Models.User.User user)
    {
        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync();
        return user;
    }
}