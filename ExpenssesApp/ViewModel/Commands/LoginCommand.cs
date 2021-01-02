using System;
using System.Windows.Input;
using ExpenssesApp.Model;

namespace ExpenssesApp.ViewModel.Commands
{
    public class LoginCommand:ICommand
    {
        public MainVM ViewModel { get; set; }
        public LoginCommand(MainVM main)
        {
            ViewModel = main;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            var user = (User)parameter;
            if(user== null)
            {
                Console.WriteLine("user null");
                return false;
            }
            if (string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Password))
                return false;
            return true;
        }

        public void Execute(object parameter)
        {
            ViewModel.Login();
        }
    }
}
