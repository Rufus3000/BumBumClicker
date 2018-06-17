using BumBumClicker.ViewModels.Abstract;
using BumBumClicker.ViewModels.ItemViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BumBumClicker.ViewModels
{
    using BumBumClicker.Backend.Data;

    using Xamarin.Forms;

    class BuildingViewModel : ViewModel
    {
        private List<BuildingItemViewModel> buildings;

        public BuildingViewModel()
        {
            this.LoadData();
            BuyCommand = new Command<int>(this.BuyCommand_Execute);
        }

        public void LoadData()
        {
            var controller = new BuildingDatabaseController();
            var list = new List<BuildingItemViewModel>();
            var buildingData = controller.GetBuildings();
            int index = 0;

            foreach(var building in buildingData)
            {
                list.Add(new BuildingItemViewModel(building));
                index++;
            }
            Buildings = list;
        }

        private async void BuyCommand_Execute(int id)
        {
            App.BuildingDatabase.BuyBuilding(id);
            this.LoadData();
        }

        public Command BuyCommand { get; set; }
        public List<BuildingItemViewModel> Buildings { get { return buildings; } set { if (buildings != value) { buildings = value; OnPropertyChanged(nameof(Buildings)); } } }
    }
}
