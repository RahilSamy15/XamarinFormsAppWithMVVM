using System;
using System.Collections.Generic;
using ExpenssesApp.ViewModel;
using Xamarin.Forms;

namespace ExpenssesApp
{
    public partial class HomePage : TabbedPage
    {
        HomeVM ViewModel;
        public HomePage()
        {
            InitializeComponent();
            ViewModel = new HomeVM();
            BindingContext = ViewModel;
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new TravelPage());
        }
    }
}
