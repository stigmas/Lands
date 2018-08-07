
namespace Lands.ViewModels
{
    using System.Windows.Input;

    class LoginViewModel
    {
        #region Properties
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsRunning { get; set; }
        public bool IsRemembered { get; set; }

        #endregion

        #region Constructors
        public LoginViewModel()
        {
            this.IsRemembered = true;
            this.IsRunning = false;
        }
        #endregion

        #region Commands
        public ICommand LoginCommand { get; set; }
        #endregion

    }
}