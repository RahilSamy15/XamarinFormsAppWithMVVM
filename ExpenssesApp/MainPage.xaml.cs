using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenssesApp.Model;
using ExpenssesApp.ViewModel;
using SQLite;
using Xamarin.Forms;

namespace ExpenssesApp
{
    public partial class MainPage : ContentPage
    {
        MainVM mainVM;
        public MainPage()
        {
            InitializeComponent();
            mainVM = new MainVM();
            BindingContext = mainVM;
            var assemblye = typeof(MainPage);
            iconImage.Source = ImageSource.FromResource("ExpenssesApp.Assets.Images.Airplane_Blue.png",assemblye);
            
        }

        
        void TabInscrip(object sender, System.EventArgs e)
        {
            this.Navigation.PushAsync(new InscriptionPage());
        }
    }
}
