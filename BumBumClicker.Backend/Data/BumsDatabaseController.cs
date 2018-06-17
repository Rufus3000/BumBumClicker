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

    public class BumsDatabaseController
    {
        
        static object locker = new object();

        SQLiteConnection database;

        public BumsDatabaseController()
        {
            this.database = DependencyService.Get<ISQLite>().GetConnection();
            this.database.CreateTable<Bums>();
        }

        public Bums GetBums()
        {
            lock (locker)
            {
                if (this.database.Table<Bums>().Count() == 0)
                    return null;
                else
                    return this.database.Table<Bums>().First();
            }
        }

        public int SaveBums(Bums bums)
        {
            lock (locker)
            {
                if (this.database.Table<Bums>().Count() > 0)
                {
                    this.database.Update(bums);
                    return bums.Id;
                }
                else
                {
                    return this.database.Insert(bums);
                }
            }
        }
    }
}
