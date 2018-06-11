using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BumBumClicker.Backend.Data
{
    using BumBumClicker.Backend.Models;
    using BumBumClicker.Data;

    using SQLite;

    using Xamarin.Forms;

    public class BuildingDatabaseController
    {
        static object locker = new object();

        SQLiteConnection database;

        public BuildingDatabaseController()
        {
            this.database = DependencyService.Get<ISQLite>().GetConnection();
            this.database.CreateTable<Building>();

            Building building = new Building();
            building.Title = "Krumpáč";
            building.Description = "Nic";
            building.Owned = false;
            building.Price = 10;
            building.Production = 10;
            this.database.Insert(building);
        }

        public Building[] GetBuildings()
        {
            lock (locker)
            {
                if (this.database.Table<Building>().Count() == 0)
                    return null;
                else
                {
                    Building[] buildings = new Building[this.database.Table<Building>().Count()];
                    for (int i = 0; i < this.database.Table<Building>().Count(); i++)
                    {
                        buildings.SetValue(this.database.Table<Building>().ElementAt(i), i);
                    }

                    return buildings;
                }
            }
        }

        public int SaveBuilding(Building building)
        {
            lock (locker)
            {
                if (building.Id != 0)
                {
                    this.database.Update(building);
                    return building.Id;
                }
                else
                {
                    return this.database.Insert(building);
                }
            }
        }
    }
}
