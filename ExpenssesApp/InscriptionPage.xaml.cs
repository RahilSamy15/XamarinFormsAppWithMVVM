using System;
using System.Collections.Generic;
using ExpenssesApp.Model;
using SQLite;
using Xamarin.Forms;

namespace ExpenssesApp
{
    public partial class InscriptionPage : ContentPage
    {
        User user;
        public InscriptionPage()
        {
            InitializeComponent();
            user = new User();
            MonStack.BindingContext = user;
        }
        void Inscrip(object sender, System.EventArgs e)
        {
            if (PASS.Text == PASSVERIFY.Text)
            {
             if(user!=null) {
                    var result = User.CreateUser(user);
                    if (result)
                        DisplayAlert("Succes", "Bien inscrit", "OK");
                    else
                        DisplayAlert("Echouer", "Erreur dans l'inscription", "OK");
                } 
               
            }
        }
    }
}
