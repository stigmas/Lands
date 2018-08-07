namespace Lands.ViewModels
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    class BaseViewModel : INotifyPropertyChanged
    {
        public void RaisePropertyChanged([CallerMemberName] string propertyName= "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}


