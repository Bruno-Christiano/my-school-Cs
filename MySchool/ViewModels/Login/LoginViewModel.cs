using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;
using MySchool.Models.Auth;
using ReactiveUI;

namespace MySchool.ViewModels.Login;

public class LoginViewModel : ReactiveObject
{
    private Auth _auth;
    public ICommand LoginCommand { get; }
    
    private string? _userName;

    public LoginViewModel()
    {
        _auth = new Auth();
        LoginCommand = new RelayCommand(()=>Login(_auth));
        
       
    }

    public string UserName
    {
        get => _auth.UserName;
        set
        {
            if (_auth.UserName != value)
            {
                _auth.UserName = value;
                this.RaisePropertyChanged(nameof(UserName));
            }
        }
    }

    private string? _password;

    public string Password
    {
        get => _auth.Password;
        set
        {
            {
                if (_auth.Password != value)
                {
                    _auth.Password = value;
                    this.RaisePropertyChanged(nameof(Password));
                }
            }
        }
    }

    private static void Login(Auth auth)
    {
        
    }
}