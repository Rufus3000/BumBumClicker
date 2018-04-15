
using BumBumClicker.DependencyServices;
using BumBumClicker.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BumBumClicker.ViewModels
{
    class MainPageViewModel : ViewModel
    {


        private byte[] imageData;

        private int _bums = 0;

        public int Bums { get { return _bums; } private set { _bums = value; OnPropertyChanged("Bums"); }}
        

        public MainPageViewModel()
        {
            ClickCommand = new Command(ClickCommand_Execute);
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

        private void ClickCommand_Execute()
        {
            Bums++;
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
        public Command ClickCommand{ get; set; }

       
    }
}
