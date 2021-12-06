using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WacMobile.Models;
using WacMobile.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: Dependency(typeof(AuthenticationService))]
namespace WacMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DashboardPage : ContentPage
    {
        private SiteUser LoggedInUser { get; }

        public DashboardPage()
        {
            InitializeComponent();

            this.BindingContext = LoggedInUser;
        }

        public DashboardPage(SiteUser _user)
        {
            InitializeComponent();

            LoggedInUser = _user;
            this.BindingContext = LoggedInUser;
        }

    }
}