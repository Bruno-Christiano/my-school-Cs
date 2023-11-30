using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using MySchool.ViewModels.UserViewModel;

namespace MySchool.Views.User.CreateUser;

public partial class CreateUserView : UserControl
{
    public CreateUserView()
    {
        InitializeComponent();
        DataContext = new UserViewModel();
        
    }
    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

}