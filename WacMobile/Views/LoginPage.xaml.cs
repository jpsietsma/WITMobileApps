using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WacMobile.Models;
using WacMobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WacMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();
        }

        private async void LoginButton_Clicked(object sender, EventArgs e)
        {
            var user = new SiteUser()
            {
                suFirstName = "Jimmy",
                suLastName = "Sietsma"
            };

            var dashboardPage = new DashboardPage(user);

            await Navigation.PushAsync(dashboardPage);
        }

        private async void CancelButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }
    }
}