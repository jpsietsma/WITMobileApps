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

        public List<string> ParticipantData { get; set; }

        public ParticipantSearchPage()
        {            
            InitializeComponent();

            DataSvc = DependencyService.Get<WITDataService>();

            ParticipantList = new List<ParticipantDetailsViewModel> { 
                new ParticipantDetailsViewModel { conID = 1, conLastName = "Sietsma", conFirstName = "Jimmy" },
                new ParticipantDetailsViewModel { conID = 2, conLastName = "Jackson", conFirstName = "John" },
                new ParticipantDetailsViewModel { conID = 3, conLastName = "Caruso", conFirstName = "Brian" },
                new ParticipantDetailsViewModel { conID = 4, conLastName = "McTester", conFirstName = "Testy" }

            };

            ParticipantListView.ItemsSource = ParticipantList;
        }


    }
}