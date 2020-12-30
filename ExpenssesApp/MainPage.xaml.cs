using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenssesApp.Model;
using SQLite;
using Xamarin.Forms;

namespace ExpenssesApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            var assemblye = typeof(MainPage);
            iconImage.Source = ImageSource.FromResource("ExpenssesApp.Assets.Images.Airplane_Blue.png",assemblye);
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            if (!string.IsNullOrEmpty(Email.Text) && !string.IsNullOrEmpty(Password.Text)) {
                 var userexist=User.UserIdentity(Email.Text, Password.Text);
                    if(userexist>0)
                        Navigation.PushAsync(new HomePage());
                
                
                   
            }
        }
        void TabInscrip(object sender, System.EventArgs e)
        {
            this.Navigation.PushAsync(new InscriptionPage());
        }
    }
}
