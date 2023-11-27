using System;
using System.Diagnostics;
using System.Windows.Input;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Layout;
using MySchool.Data;
using MySchool.Models.Auth;
using MySchool.Services.Auth;
using MySchool.Views;
using MySchool.Views.Home;
using Newtonsoft.Json;
using ReactiveUI;

using CustomMessageBox.Avalonia;


namespace MySchool.ViewModels.Login;

using Avalonia.Interactivity;

public class LoginViewModel : ReactiveObject
{
    public Auth _auth;

    public ICommand LoginCommand { get; }
    private bool _isLoading;

    public bool IsLoading
    {
        get => _isLoading;
        set
        {
            if (_isLoading != value)
            {
                _isLoading = value;
               this.RaisePropertyChanged(nameof(IsLoading));
            }
        }
    }
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


    private static void GoToHomePage(Auth auth)
    {
        var homeViewModel = new HomeViewModel.HomeViewModel
            { Auth = auth };
        var homeView = new HomeView { DataContext = homeViewModel };
        homeView.Show();
        CloseLogin();
    }


    private void Login(Auth auth)
    {
        IsLoading = true;
        using var dbContext = new ApplicationDbContext();

        {
            var authService = new AuthService(dbContext);

            string userName = auth.UserName;
            string password = auth.Password;

            if (authService.AuthenticateUser(userName, password))
            {
                IsLoading = false;
                GoToHomePage(auth);
            }
            else
            {
             
                var messageBox = new MessageBox(
                    "Usuário inválido",
                    "Acesso negado", MessageBoxIcon.Error)
                {
                    HorizontalButtonsPanelAlignment = HorizontalAlignment.Center
                };
                
                var result = messageBox.Show(
                    new MessageBoxButton<MessageBoxResult>("Fechar",
                        MessageBoxResult.Yes, SpecialButtonRole.IsDefault));

            }
        }
    }


    private static void CloseLogin()
    {
        (Application.Current.ApplicationLifetime as
            IClassicDesktopStyleApplicationLifetime)?.MainWindow?.Close();
    }
}