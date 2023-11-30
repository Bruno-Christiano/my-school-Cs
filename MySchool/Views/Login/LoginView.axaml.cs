using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Avalonia.Media.Imaging;
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


    public void ToggleButtonChecked(object sender, RoutedEventArgs e)
    {
        /*Console.WriteLine(nametest.Text);*/

        /*
        if (PasswordTextBox.PasswordChar == '\0')
        {
            // Senha visível, ocultar senha e alterar ícone
            PasswordTextBox.PasswordChar = '*';''
            /*EyeIcon.Source = new Bitmap("/Assets/eye.png");#1#
        }
        else
        {
            // Senha oculta, mostrar senha e alterar ícone
            PasswordTextBox.PasswordChar = '\0';
            /*EyeIcon.Source = new Bitmap("/Assets/eye_hidden.png");#1#
        }
        */
    }



    private void VerifyForm(object? sender, GotFocusEventArgs e)
    {

    }


}