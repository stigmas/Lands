
namespace Lands.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Lands.Views;
    using System;
    using System.ComponentModel;
    using System.Windows.Input;
    using Xamarin.Forms;

    class LoginViewModel : BaseViewModel
    {
        #region Attributes
        private string password;
        private string email;
        private bool isRunning;
        private bool isEnabled;
        #endregion

        #region Properties
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                this.email = value;
                RaisePropertyChanged("Email");
            }
        }
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                this.password = value;
                RaisePropertyChanged("Password");
            }
        }

        public bool IsRunning
        {
            get
            {
                return isRunning;
            }
            set
            {
                this.isRunning = value;
                RaisePropertyChanged("IsRunning");
            }
        }

        public bool IsEnabled
        {
            get
            {
                return isEnabled;
            }
            set
            {
                this.isEnabled = value;
                RaisePropertyChanged("IsEnabled");
            }
        }

        public bool IsRemembered { get; set; }
        
        #endregion

        #region Constructors
        public LoginViewModel()
        {
            //restcountries.eu/rest/v2/all
            this.Email = "jgallego@eurofic.com";
            this.Password = "1234";
            this.IsRemembered = true;
            this.IsRunning = false;
            this.IsEnabled = true;
        }
        #endregion

        #region Commands
        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(Login);
            }
        }


        private async void Login()
        {
            if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error", "You must enter an email", "Accept");
                return;
            }

            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error", "You must enter a password", "Accept");
                return;
            }

            this.IsRunning = true;
            this.IsEnabled = false;

            if (this.Email != "jgallego@eurofic.com" || this.Password != "1234")
            {
                this.IsRunning = false;
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert(
                    "Error", "Email or password incorrect", "Accept");
                this.Password = string.Empty;
                return;
            }

            this.IsRunning = false;
            this.IsEnabled = true;

            //this.Email = string.Empty;
            //this.Password = string.Empty;

            MainViewModel.GetInstance().Lands = new LandsViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new LandsPage());
        }
        #endregion

    }
}