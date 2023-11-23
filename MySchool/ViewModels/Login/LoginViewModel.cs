using System.Diagnostics;
using System.Windows.Input;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using MySchool.Models.Auth;
using MySchool.Views;
using MySchool.Views.Home;
using Newtonsoft.Json;
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
        LoginCommand = new RelayCommand(() => Login(_auth));
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


    private void GoToHomePage()
    {
        var homeView = new HomeView();
        homeView.Show();
        CloseLogin();
    }


    private void Login(Auth auth)
    {
        string json = JsonConvert.SerializeObject(auth);
        
        Debug.WriteLine(json);
        /*GoToHomePage();*/
    }


    private static void CloseLogin()
    {
        (Application.Current.ApplicationLifetime as
            IClassicDesktopStyleApplicationLifetime)?.MainWindow?.Close();
    }
}