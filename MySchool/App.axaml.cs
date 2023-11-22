using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using MySchool.ViewModels;
using MySchool.ViewModels.Login;
using MySchool.Views;
using MySchool.Views.Login;

namespace MySchool;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new LoginView()
            {
                DataContext = new LoginViewModel(),
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}