using System;
using System.ComponentModel;
using ExpenssesApp.Model;
using ExpenssesApp.ViewModel.Commands;

namespace ExpenssesApp.ViewModel
{
    public class MainVM:INotifyPropertyChanged
    {
        private User user;
        public User User
        {
            get { return user; }

            set { user = value;
                OnPropertyChanged("User");
            }
        }
        public LoginCommand LoginCommand { get; set; }
        

        public event PropertyChangedEventHandler PropertyChanged;

        private string email;
        public string Email
        {
            get { return email; }
            set { email = value;
                User = new User() { Email = this.Email, Password = this.Password }; 
                OnPropertyChanged("Email");
            }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                User = new User() { Email = this.Email, Password = this.Password };
                OnPropertyChanged("Password");
            }
        }
        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
        public MainVM()
        {
            User = new User();
            LoginCommand = new LoginCommand(this);
        }
        public async void Login()
        {
            var userexist = User.UserIdentity(User.Email, User.Password);
            if (userexist > 0)
              await  App.Current.MainPage.Navigation.PushAsync(new HomePage());
            else
              await  App.Current.MainPage.DisplayAlert("Error", "Auth error", "ok");
        }
    }
}
