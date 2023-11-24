using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using MySchool.Models.Auth;
using MySchool.ViewModels.HomeViewModel;

namespace MySchool.Views.Home;

public partial class HomeView : Window
{
    public HomeView()
    {
        InitializeComponent();
        DataContext = new HomeViewModel();

    }
    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}