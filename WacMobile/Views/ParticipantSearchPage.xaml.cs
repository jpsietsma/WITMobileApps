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
    public partial class ParticipantSearchPage : ContentPage
    {
        private WITDataService DataSvc;
        public List<ParticipantDetailsViewModel> ParticipantList { get; set; }


        public ParticipantSearchPage()
        {            
            InitializeComponent();

            DataSvc = DependencyService.Get<WITDataService>();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            ParticipantList = await DataSvc.GetParticipants();
            participantPicker.ItemsSource = ParticipantList;
        }

        private void participantSearchButton_Clicked(object sender, EventArgs e)
        {
            var participantSelected = participantPicker.SelectedItem as ParticipantDetailsViewModel;

            Navigation.PushAsync(new ParticipantDetailsPage(participantSelected.conID));
        }
    }
}