using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WacMobile.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: Dependency(typeof(WITDataService))]
namespace WacMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ParticipantDetailsPage : ContentPage
    {
        private WITDataService DataSvc;

        public ParticipantDetailsPage(int partID)
        {
            InitializeComponent();

            DataSvc = DependencyService.Get<WITDataService>();
        }
    }
}