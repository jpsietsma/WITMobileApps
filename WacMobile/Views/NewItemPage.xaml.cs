using System;
using System.Collections.Generic;
using System.ComponentModel;
using WacMobile.Models;
using WacMobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WacMobile.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}