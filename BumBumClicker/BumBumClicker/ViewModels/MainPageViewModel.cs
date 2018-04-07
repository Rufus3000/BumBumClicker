
using BumBumClicker.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BumBumClicker.ViewModels
{
    class MainPageViewModel : ViewModel
    {
        private int _bums = 0;

        public int Bums { get { return _bums; } private set { _bums = value; OnPropertyChanged("Bums"); }}
        

        public MainPageViewModel()
        {
            ClickCommand = new Command(ClickCommand_Execute);

        }

        private void ClickCommand_Execute()
        {
            Bums++;
        }

        public Command ClickCommand{ get; set; }

       
    }
}
