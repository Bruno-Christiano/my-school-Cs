using System;
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
                    /*ValidateForm("password");*/
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
        /*// Validar o modelo User usando o validador
        var userValidator = new LoginValidator();
        var validationResult = userValidator.Validate(new Auth()
            { UserName = auth.UserName, Password = auth.Password });*/
        /*var loginValidator = new LoginValidator();
        ValidationResult = loginValidator.Validate(auth);

        // Verificar se a validação falhou'
        if (!ValidationResult.IsValid)
        {
            // Manipular os erros de validação conforme necessário
            foreach (var error in ValidationResult.Errors)
            {
                Debug.WriteLine($"Validation error: {error.ErrorMessage}");
            }

            return;
        }*/


        using var dbContext = new ApplicationDbContext();

        {
            var authService = new AuthService(dbContext);

            string userName = auth.UserName;
            string password = auth.Password;

            if (authService.AuthenticateUser(userName, password))
            {
             
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

    public string UserNameError
    {
        get => _auth.UserNameError;
        set
        {
            _auth.UserNameError = value;
            this.RaisePropertyChanged(nameof(UserNameError));
        }
    }

    public void ValidateForm(string? userName="UserName", string? password = "")
    {
        
        // a validação do form acontece por qque vai ser chamdado a qualquer momento.
        
   var loginValidator = _loginValidator.Validate(new Auth { UserName = UserName, Password = Password });
   UserNameError =string.Empty;
   
        if (!loginValidator.IsValid)
        {
            foreach (var failure in loginValidator.Errors)
            {

                if (failure.PropertyName == userName)
                {
                    Console.WriteLine(failure.ErrorMessage);
                    UserNameError = failure.ErrorMessage;
                }
                if (failure.PropertyName == password)
                {
                    Console.WriteLine(failure.ErrorMessage);
                    UserNameError = failure.ErrorMessage;
                }
                /*Console.WriteLine($"Property: {failure.PropertyName}, Error: {failure.ErrorMessage}");*/
            }
        }
        
        
    }
}