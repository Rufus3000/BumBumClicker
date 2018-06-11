using System;
using System.Collections.Generic;
using System.Text;
using BumBumClicker.DependencyServices;
using BumBumClicker.ViewModels.Abstract;

using Xamarin.Forms;

namespace BumBumClicker.ViewModels
{
    using BumBumClicker.Backend.Data;
    using BumBumClicker.Backend.Models;

    class ProfilePageViewModel : ViewModel
    {
        private byte[] imageData = { 0x0000 };

        private string name = "";

        public ProfilePageViewModel()
        {
            UserDatabaseController controller = new UserDatabaseController();
            var user = controller.GetUser();
            if (user != null)
            {
                imageData = user.Image;
                name = user.Name;
            }
            AddPictureCommand = new Command(AddPictureCommand_Execute);
            SaveCommand = new Command(this.SaveCommand_Execute);
        }

        private async void AddPictureCommand_Execute(object obj)
        {
            var gallery = "Fotogalerie";
            var camera = "Vyfotit";
            var result = await App.Current.MainPage.DisplayActionSheet("Vložit fotografii", null, null, gallery, camera);
            var picturePicker = DependencyService.Get<IPicturePicker>();
            if (string.Equals(gallery, result))
            {
                ImageData = await picturePicker.GetPictureFromGallery();
            }
            else if (string.Equals(camera, result))
            {
                ImageData = await picturePicker.GetPictureFromCamera();
            }
        }

        private async void SaveCommand_Execute()
        {
            if(Name != "")
            {
                User user = new User(Name, ImageData);
                App.UserDatabase.SaveUser(user);
            }
        }
        
        public byte[] ImageData
        {
            get
            {
                return this.imageData;
            }
            set
            {
                if (this.imageData != value)
                {
                    this.imageData = value;
                    this.OnPropertyChanged(nameof(ImageData));
                }
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (this.name != value)
                {
                    this.name = value;
                    this.OnPropertyChanged(nameof(Name));
                }
            }
        }

        public Command AddPictureCommand { get; set; }
        public Command SaveCommand { get; set; }
    }
}
