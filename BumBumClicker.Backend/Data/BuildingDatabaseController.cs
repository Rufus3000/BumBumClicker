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
            /*
            Building building = new Building();
            building.Title = "Továrna";
            building.Description = "Nic";
            building.Owned = false;
            building.Price = 10;
            building.Production = 20;

            this.database.Insert(building);
            */
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

        public List<int> GetProduction()
        {
            lock (locker)
            {
                List<int> productions = new List<int>();
                var comm = this.database.CreateCommand("select * from Building");
                var all = comm.ExecuteQuery<Building>();
                var command = this.database.CreateCommand("Select Production from Building where Owned = 1");
                var production = command.ExecuteQuery<Building>();

                foreach (var product in production)
                {
                    productions.Add(product.Production);
                }

                return productions;
            }
        }

        public void BuyBuilding(int id)
        {
            lock (locker)
            {
                this.database.Execute("UPDATE [Building] SET Owned = 1 WHERE Id ='" + id.ToString() + "'");
            }
        }

        public int SaveBuilding(Building building)
        {
            lock (locker)
            {
                if (this.database.Table<Building>().Count() > 0)
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
