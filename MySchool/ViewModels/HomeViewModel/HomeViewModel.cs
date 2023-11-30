using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using System.Windows.Input;
using Avalonia.Controls;
using DialogHostAvalonia;
using MessageBoxSlim.Avalonia;
using MySchool.Models.Auth;
using MySchool.Models.User;
using MySchool.Views.User.CreateUser;
using Newtonsoft.Json;
using ReactiveUI;

namespace MySchool.ViewModels.HomeViewModel;

public class HomeViewModel : ReactiveObject
{
    private Auth _auth;
  
    public ICommand OpenWindowUserCommand { get; }
    
    private UserControl _createUserView;
    
    public HomeViewModel()
    {
        OpenWindowUserCommand =
            new RelayCommand(() => OpenWindowRegisterUser());
    }


    public Auth Auth
    {
        get => _auth;
        set
        {
            if (_auth != value)
            {
                _auth = value;
                this.RaisePropertyChanged(nameof(Auth));
            }
        }
    }
    
    
    public UserControl CreateUserView
    {
        get => _createUserView;
        set => this.RaiseAndSetIfChanged(ref _createUserView, value);
    }

    public void OpenWindowRegisterUser()
    {
        var userRegistrationView = new CreateUserView(); // Substitua esta linha com sua lógica de criação do UserRegistrationView
        CreateUserView = userRegistrationView;
        
    }


  
}