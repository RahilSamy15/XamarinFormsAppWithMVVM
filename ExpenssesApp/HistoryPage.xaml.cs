using System;
using System.Collections.Generic;
using ExpenssesApp.Model;
using SQLite;
using Xamarin.Forms;

namespace ExpenssesApp
{
    public partial class HistoryPage : ContentPage
    {
        public HistoryPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            var posts = Post.GetList();
                postListView.ItemsSource = posts;
            
        }
    }
}
