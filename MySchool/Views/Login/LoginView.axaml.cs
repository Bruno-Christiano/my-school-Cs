using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using MySchool.ViewModels.Login;

namespace MySchool.Views.Login;

public partial class LoginView : Window
{
    public LoginView()
    {
        InitializeComponent();
        this.DataContext = new LoginViewModel();
    }
    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

  
}