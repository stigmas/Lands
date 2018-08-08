namespace Lands.ViewModels
{
    using Lands.Models;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Services;
    using Xamarin.Forms;

    public class LandsViewModel: BaseViewModel
    {
        #region Services
        private ApiService apiService;
        #endregion

        #region Attributes
        private ObservableCollection<Land> lands; //el observable podria ser List, pero como quiero que se refresque, ya que quiero pintarla en un listview
        #endregion

        #region Properties
        public ObservableCollection<Land> Lands
        {
            get {return this.lands; }
            set
            {
                this.lands = value;
                RaisePropertyChanged("Lands");
            }
        }
        #endregion

        #region Constructors
        public LandsViewModel()
        {
            this.apiService = new ApiService();
            this.LoadLands();
        }
        #endregion


        #region Methods
        private async void LoadLands()
        {
            var response = await this.apiService.GetList<Land>(
                "http://restcountries.eu",
                "/rest",
                "/v2/all");

            if (response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Message,
                    "Accept");
            }

            var list = (List<Land>)response.Result;
            this.Lands = new ObservableCollection<Land>(list);
        } 
        #endregion

    }
}
