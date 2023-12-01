using System;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using MySchool.Models.Auth;
using MySchool.ViewModels.Login;
using MySchool.ViewModels.UserViewModel;

namespace MySchool.Views.Login;

public partial class LoginView : Window
{
    private TextBox? _myTextBox;

    public LoginView()
    {
        InitializeComponent();
        this.DataContext = new LoginViewModel();
        // Encontrar o TextBox no XAML usando FindControl
        /*_myTextBox = this.FindControl<TextBox>("UserNameText");*/

    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
    
}