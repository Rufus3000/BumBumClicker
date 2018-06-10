using System;
using System.Collections.Generic;
using System.Text;
using BumBumClicker.DependencyServices;
using BumBumClicker.ViewModels.Abstract;

using Xamarin.Forms;

namespace BumBumClicker.ViewModels
{
    class ProfilePageViewModel : ViewModel
    {
        private byte[] imageData = { 0x0000 };

        public ProfilePageViewModel()
        {
            AddPictureCommand = new Command(AddPictureCommand_Execute);
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
        public Command AddPictureCommand { get; set; }
    }
}
