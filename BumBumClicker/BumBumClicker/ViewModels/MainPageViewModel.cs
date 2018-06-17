
using BumBumClicker.DependencyServices;
using BumBumClicker.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using BumBumClicker.Backend.Data;

namespace BumBumClicker.ViewModels
{
    using BumBumClicker.Backend.Models;

    class MainPageViewModel : ViewModel
    {
        private int _bums;

        private int _bumsPerClick;

        public int Bums { get { return _bums; } private set { _bums = value; OnPropertyChanged("Bums"); }}
        
        public int BumsPerClick { get{ return this._bumsPerClick; } private set { this._bumsPerClick = value; this.OnPropertyChanged("BumsPerClick"); }}

        public MainPageViewModel()
        {
            this.LoadBums();   

            BuildingDatabaseController bController = new BuildingDatabaseController();
            var productions = bController.GetProduction();
            if (productions != null)
            {
                foreach (int production in productions)
                {
                    this._bumsPerClick += production;
                }
            }

            ClickCommand = new Command(ClickCommand_Execute);
        }

        private void LoadBums()
        {
            BumsDatabaseController controller = new BumsDatabaseController();
            var bum = controller.GetBums();
            if (bum != null)
                this._bums = bum.BumBums;
        }
        
        
        private void ClickCommand_Execute()
        {
            Bums bums = new Bums(this.Bums + this.BumsPerClick);
            App.BumsDatabase.SaveBums(bums);
            this.Bums += this.BumsPerClick;
        }

        public Command ClickCommand{ get; set; }
    }
}
