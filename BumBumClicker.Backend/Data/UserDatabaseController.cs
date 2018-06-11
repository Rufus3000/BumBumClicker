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

    public class UserDatabaseController
    {
        static object locker = new object();

        SQLiteConnection database;

        public UserDatabaseController()
        {
            this.database = DependencyService.Get<ISQLite>().GetConnection();
            this.database.CreateTable<User>();
        }

        public User GetUser()
        {
            lock (locker)
            {
                if (this.database.Table<User>().Count() == 0)
                    return null;
                else
                    return this.database.Table<User>().First();
            }
        }

        public int SaveUser(User user)
        {
            lock (locker)
            {
                if (user.Id != 0)
                {
                    this.database.Update(user);
                    return user.Id;
                }
                else
                {
                    return this.database.Insert(user);
                }
            }
        }
    }
}
