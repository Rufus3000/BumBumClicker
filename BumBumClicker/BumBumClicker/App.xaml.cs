using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BumBumClicker.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BumBumClicker
{
    using BumBumClicker.Backend.Data;

    public partial class App : Application
    {
        private static BuildingDatabaseController buildingDatabase;

        private static UserDatabaseController userDatabase;

		public App ()
		{
			InitializeComponent();

            MainPage = new NavigationPage(new Views.MainPage());
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}

        public static UserDatabaseController UserDatabase
        {
            get
            {
                if(userDatabase == null)
                    userDatabase = new UserDatabaseController();
                return userDatabase;
            }
        }

        public static BuildingDatabaseController BuildingDatabase
        {
            get
            {
                if(buildingDatabase == null)
                    buildingDatabase = new BuildingDatabaseController();
                return buildingDatabase;
            }
        }
	}
}
