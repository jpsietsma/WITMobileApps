using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WacMobile.Models;
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
        private int ParticipantID { get; set; }
        private ParticipantDetailsViewModel ParticipantInfo { get; set; }

        public ParticipantDetailsPage(int partID)
        {
            InitializeComponent();

            DataSvc = DependencyService.Get<WITDataService>();

            ParticipantID = partID;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();    
            
            ParticipantInfo = await DataSvc.GetParticipantDetails(ParticipantID);

            ParticipantInfo.conIsDeceased = ParticipantInfo.conIsDeceased ?? false;
            ParticipantInfo.conIsActive = ParticipantInfo.conIsActive ?? false;

            BindingContext = ParticipantInfo;
        }
    }
}