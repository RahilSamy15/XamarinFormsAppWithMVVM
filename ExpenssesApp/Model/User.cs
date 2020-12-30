using System;
using System.ComponentModel;
using SQLite;

namespace ExpenssesApp.Model
{
    public class User:INotifyPropertyChanged
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }


        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnpropertyChanged("Email");
            }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnpropertyChanged("Password");
            }
        }
      

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnpropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this,new PropertyChangedEventArgs(propertyName));
        }

        public static int UserIdentity(string Email, string Password)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.databLocation))
            {
                conn.CreateTable<User>();
                var Users = conn.Table<User>();
                var userexist = (from use in Users
                                 where use.Email == Email && use.Password == Password

                                 select use).ToList().Count;
                return userexist;
            }
            return 0;
        }
        public static int userExist(string email)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.databLocation))
            {
                conn.CreateTable<User>();
                var Users = conn.Table<User>();
                var userexist = (from use in Users
                                 where use.Email == email
                                 select use).ToList().Count;
                return userexist;
            }
            return 0;
        }
        public static bool CreateUser(User user)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.databLocation))
            {
                conn.CreateTable<User>();
                var Users = conn.Table<User>();
                var userexist = User.userExist(user.Email);
                if (userexist == 0)
                {
                    int row = conn.Insert(user);
                    if (row > 0)
                        return true;
                   
                }

            }
            return false;
        }
    }
}
