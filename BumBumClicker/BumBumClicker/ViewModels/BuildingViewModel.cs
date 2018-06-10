using BumBumClicker.Backend.Managers;
using BumBumClicker.ViewModels.Abstract;
using BumBumClicker.ViewModels.ItemViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BumBumClicker.ViewModels
{
    class BuildingViewModel : ViewModel
    {
        private List<BuildingItemViewModel> buildings;

        public BuildingViewModel()
        {
            this.LoadData();
        }

        public async Task LoadData()
        {
            var manager = new BuildingManager();
            var list = new List<BuildingItemViewModel>();
            var buildingData = await manager.GetBuildings();

            foreach(var building in buildingData)
            {
                list.Add(new BuildingItemViewModel(building));
            }
            Buildings = list;
        }

        public List<BuildingItemViewModel> Buildings { get { return buildings; } set { if (buildings != value) { buildings = value; OnPropertyChanged(nameof(Buildings)); } } }
    }
}
