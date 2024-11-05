using System.ComponentModel;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace Pokedex.ViewModel;

public partial class BaseViewModel:ObservableObject
{
    [ObservableProperty]
    [AlsoNotifyChangeFor(nameof(isNotBusy))]
    bool _isBusy;
    [ObservableProperty]
    string _title;

    /*public bool IsBusy
    {
        get => _isBusy;
        set
        {
            if (value == _isBusy) return;
            _isBusy = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(isNotBusy));
        }
    }

    public string Title
    {
        get => _title;
        set
        {
            if (value == _title) return;
            _title = value;
            OnPropertyChanged();
        }
    }*/
    
    public bool isNotBusy => !IsBusy;
    
}