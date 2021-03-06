using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WacMobile.Models;
using WacMobile.Services;
using WacMobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: Dependency(typeof(AuthenticationService))]
namespace WacMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]    
    public partial class LoginPage : ContentPage
    {
        private AuthenticationService AuthSvc;

        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();
            AuthSvc = DependencyService.Get<AuthenticationService>();

            /*Remove these when testing is complete and application is ready to be deployed */
            userName.Text = "jsietsma@nycwatershed.org";
            password.Text = "A!12@lop^6";

        }

        private async void LoginButton_Clicked(object sender, EventArgs e)
        {
            errorPlaceholder.Text = "Logging in... Please wait.";
            errorPlaceholder.FontAttributes = FontAttributes.Bold;

            AuthSvc.UserName = userName.Text;
            AuthSvc.Password = password.Text;
                        
            var response = await AuthSvc.AuthenticateUserAsync();

            if (response.User != null)
            {
                errorPlaceholder.Text = null;
                await Navigation.PushAsync(new DashboardPage(response.User));
            }
            else
            {
                errorPlaceholder.TextColor = Color.Red;
                errorPlaceholder.Text = response.Message;
            }

        }

        private async void CancelButton_Clicked(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                userName.Text = string.Empty;
                password.Text = string.Empty;
                errorPlaceholder.TextColor = Color.Red;
                errorPlaceholder.FontAttributes = FontAttributes.Bold;
                errorPlaceholder.Text = "You must login to continue.";
            });                        
        }
    }
}