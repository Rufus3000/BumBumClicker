using BumBumClicker.ViewModels.Abstract;
using BumBumClicker.ViewModels.ItemViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BumBumClicker.ViewModels
{
    using BumBumClicker.Backend.Data;

    class BuildingViewModel : ViewModel
    {
        private List<BuildingItemViewModel> buildings;

        public BuildingViewModel()
        {
            this.LoadData();
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

        public List<BuildingItemViewModel> Buildings { get { return buildings; } set { if (buildings != value) { buildings = value; OnPropertyChanged(nameof(Buildings)); } } }
    }
}
