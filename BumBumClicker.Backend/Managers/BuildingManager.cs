using BumBumClicker.Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BumBumClicker.Backend.Managers
{
    public class BuildingManager
    {
        private static List<Building> buildings = new List<Building>();
        

        public BuildingManager()
        {
            Building building = new Building();
            building.Title = "Pickaxe";
            building.Price = 0;
            building.Production = 0;
            building.Description = "Diamantový krumpáč";
            buildings.Add(building);
        }

        public async Task<bool> AddViewPoint(Building building)
        {
            try
            {
                buildings.Add(building);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public async Task<List<Building>> GetBuildings()
        {
            return buildings;
        }
    }
}
