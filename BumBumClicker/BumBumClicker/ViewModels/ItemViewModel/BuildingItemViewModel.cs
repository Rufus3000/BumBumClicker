using System;
using System.Collections.Generic;
using System.Text;
using BumBumClicker.Backend.Models;

namespace BumBumClicker.ViewModels.ItemViewModel
{
    class BuildingItemViewModel : Abstract.ViewModel
    {
        private Building model;

        public BuildingItemViewModel(Building building)
        {

            model = building;

            this.model = building;

        }

        public string Title
        {
            get
            {

                return model.Title;
            }
            set
            {
                if (model.Title != value)
                {
                    model.Title = value;
                    OnPropertyChanged();
                    
                }

            }
        }
        public string Description
        {
            get
            {

                return model.Description;
            }
            set
            {
                if (model.Description != value)
                {
                    model.Description = value;
                    OnPropertyChanged(nameof(Description));
                }
            }
        }

        public int Price
        {
            get
            {
                return model.Price;
            }
            set
            {
                if (model.Price != value)
                {
                    model.Price = value;
                    OnPropertyChanged(nameof(Price));
                }
            }
        }

    }
}
