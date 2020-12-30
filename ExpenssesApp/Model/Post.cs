using System;
using System.Collections.Generic;
using System.ComponentModel;
using SQLite;

namespace ExpenssesApp.Model
{
    public class Post : INotifyPropertyChanged
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        

        private string experience;
        [MaxLength(250)]
        public string Experience
        {
             get{return experience; }
             set{ experience = value;
                OnPropertyChanger("Experience");
            }
        }

        private string venueName;
        public string VenueName
        {
            get { return venueName; }
            set
            {
                venueName = value;
                OnPropertyChanger("VenueName");
            }
        }
        private string categoryId;
        public string CategoryId
        {
            get { return categoryId; }
            set
            {
                categoryId = value;
                OnPropertyChanger("CategoryId");
            }
        }
        private string categoryName;
        public string CategoryName
        {
            get { return categoryName; }
            set
            {
                categoryName = value;
                OnPropertyChanger("CategoryName");
            }
        }
        private string address;
        public string Address
        {
            get { return address; }
            set
            {
                address = value;
                OnPropertyChanger("Address");
            }
        }

        private double latitude;
        public double Latitude
        {
            get { return latitude; }
            set
            {
                latitude = value;
                OnPropertyChanger("Latitude");
            }
        }

        private double longitude;
        public double Longitude
        {
            get { return longitude; }
            set
            {
                longitude = value;
                OnPropertyChanger("Longitude");
            }
        }

        private int distance;
        public int Distance
        {
            get { return distance; }
            set
            {
                distance = value;
                OnPropertyChanger("Distance");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public static List<Post> GetList()
        {
            var res= new List<Post>();
            using (SQLiteConnection conn = new SQLiteConnection(App.databLocation))
            {
                conn.CreateTable<Post>();
                var posts = conn.Table<Post>().ToList();
                res = posts;
                return posts;
            }
            return res;
        }
        public static int InsertPost(Post post)
        {

            using (SQLiteConnection conn = new SQLiteConnection(App.databLocation))
            {
                conn.CreateTable<Post>();
                int row = conn.Insert(post);
                return row;


            }
        }
        private void OnPropertyChanger(string propertyName)
        {
            if(PropertyChanged!=null)
             PropertyChanged(this,new PropertyChangedEventArgs( propertyName));
        }
    }
}
