using BumBumClicker.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BumBumClicker.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : ContentPage
	{
        private MainPageViewModel viewModel;

        public MainPage()
        {
            InitializeComponent();
            this.viewModel = new MainPageViewModel();
            this.BindingContext = this.viewModel;
        }

        private void Store_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new BuildingPage());
        }
        
	}
}