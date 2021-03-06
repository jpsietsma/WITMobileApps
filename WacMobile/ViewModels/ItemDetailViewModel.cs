using System;
using System.Diagnostics;
using System.Threading.Tasks;
using WacMobile.Models;
using Xamarin.Forms;

namespace WacMobile.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        private string itemId;
        private string text;
        private string description;
        public string Id { get; set; }

        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }
                        
    }
}
