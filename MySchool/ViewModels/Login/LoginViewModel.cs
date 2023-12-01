using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Input;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Layout;
using Avalonia.Media;
using MySchool.Data;
using MySchool.Models.Auth;
using MySchool.Services.Auth;
using MySchool.Views;
using MySchool.Views.Home;
using Newtonsoft.Json;
using ReactiveUI;
using CustomMessageBox.Avalonia;
using FluentValidation.Results;
using MySchool.Models.User;
using MySchool.Resources.Shared.Validators;


namespace MySchool.ViewModels.Login;

using Avalonia.Interactivity;

public class LoginViewModel : ReactiveObject
{
    public Auth _auth;
    private LoginValidator _loginValidator;
    public ICommand LoginCommand { get; }
    

    public LoginViewModel()
    {
        _auth = new Auth();
        LoginCommand = new RelayCommand(() => Login(_auth));
        _loginValidator = new LoginValidator();
    }

   

    private string? _userName;


    public string UserName
    {
        get => _auth.UserName;
        set
        {
            if (_auth.UserName != value)
            {
                _auth.UserName = value;
                //validação séra feito dinamica, quando o usuário digitar
                ValidateForm("UserName");
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
                    ValidateForm("Password");
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
        
     using var dbContext = new ApplicationDbContext();
     var authService = new AuthService(dbContext);

     string userName = auth.UserName;
     string password = auth.Password;

     var loginValidator = _loginValidator.Validate(new Auth { UserName = userName, Password = password });

     if (loginValidator.IsValid)
     {
         if (authService.AuthenticateUser(userName, password))
         {
             GoToHomePage(auth);
         }
         else
         {
             ShowAuthenticationError();
         }
     }
     else
     {
         ShowValidationErrors(loginValidator.Errors);
     }
     
    }
    private void ShowValidationErrors(IEnumerable<ValidationFailure> errors)
    {
        foreach (var failure in errors)
        {
            switch (failure.PropertyName)
            {
                case "UserName":
                    UserNameError = failure.ErrorMessage;
                    break;
                case "Password":
                    UserPasswordError = failure.ErrorMessage;
                    break;
            }
        }
    }

    private void ShowAuthenticationError()
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

    private static void CloseLogin()
    {
        (Application.Current.ApplicationLifetime as
            IClassicDesktopStyleApplicationLifetime)?.MainWindow?.Close();
    }

    public string UserNameError
    {
        get => _auth.UserNameError;
        set
        {
            _auth.UserNameError = value;
            this.RaisePropertyChanged(nameof(UserNameError));
        }
    }
    public string UserPasswordError
    {
        get => _auth.UserPasswordError;
        set
        {
            _auth.UserPasswordError = value;
            this.RaisePropertyChanged(nameof(UserPasswordError));
        }
    }

    private void ValidateForm(string? fieldName = null)
    {
        var loginValidator = _loginValidator.Validate(new Auth { UserName = UserName, Password = Password });
        // a validação do form acontece por qque vai ser chamdado a qualquer momento.
        switch (fieldName)
        {
            case "UserName":
                UserNameError = string.Empty;
                break;
            case "Password":
                UserPasswordError = string.Empty;
                break;
            default:
                UserNameError = string.Empty;
                UserPasswordError = string.Empty;
                break;
        }
        
        
        if (!loginValidator.IsValid)
        {
            foreach (var failure in loginValidator.Errors)
            {
                switch (failure.PropertyName)
                {
                    case "UserName" when fieldName == "UserName":
                        UserNameError = failure.ErrorMessage;
                        break;
                    case "Password" when fieldName == "Password":
                        UserPasswordError = failure.ErrorMessage;
                        break;
                }
            }
        }
        
    }
}