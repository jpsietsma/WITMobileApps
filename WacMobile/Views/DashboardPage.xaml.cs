using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WacMobile.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WacMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DashboardPage : ContentPage
    {
        private SiteUser LoggedInUser { get; }
        public DashboardPage(SiteUser _user)
        {
            InitializeComponent();

            LoggedInUser = _user;
            this.BindingContext = LoggedInUser;
        }

    }
}