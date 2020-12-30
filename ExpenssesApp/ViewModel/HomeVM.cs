using System;
using ExpenssesApp.ViewModel.Commands;

namespace ExpenssesApp.ViewModel
{
    public class HomeVM
    {
        public NavigationCommand NavCommand { get; set; }
        public HomeVM()
        {
            NavCommand = new NavigationCommand(this);

        }
        public void Navigate()
        {

        }
            
    }
}
