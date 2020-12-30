using System;
using System.Collections.Generic;
using ExpenssesApp.Model;
using SQLite;
using System.Linq;
using Xamarin.Forms;

namespace ExpenssesApp
{
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (SQLiteConnection conn = new SQLiteConnection(App.databLocation))
            {
                var postTable = conn.Table<Post>().ToList();
                var categories = (from p in postTable
                                  orderby p.CategoryId
                                  select p.CategoryName).Distinct().ToList();


                Dictionary<string, int> categoriesnbr = new Dictionary<string, int>();
                foreach (var category in categories)
                {
                    var count = (from post in postTable
                                 where post.CategoryName == category
                                 select post).ToList().Count;
                    if(category != null) {
                        categoriesnbr.Add(category, count);
                    }
                }
                CatergoriesList.ItemsSource = categoriesnbr;
                postcompterLabel.Text = postTable.Count.ToString();
            }
          



        }
        }
        }

