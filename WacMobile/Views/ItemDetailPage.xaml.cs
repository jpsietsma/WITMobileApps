using System.ComponentModel;
using WacMobile.ViewModels;
using Xamarin.Forms;

namespace WacMobile.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}