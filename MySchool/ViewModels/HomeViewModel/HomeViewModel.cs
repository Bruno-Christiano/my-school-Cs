using MySchool.Models.Auth;
using ReactiveUI;

namespace MySchool.ViewModels.HomeViewModel;

public class HomeViewModel :ReactiveObject
{
    private Auth _auth;
    
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

    public HomeViewModel()
    {
        _auth = new Auth();
    }
}