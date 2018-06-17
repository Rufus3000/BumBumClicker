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
            this.model = building;
        }

        public int Id
        {
            get
            {
                return this.model.Id;
            }
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

        public int Production
        {
            get
            {
                return this.model.Production;
            }
            set
            {
                if (this.model.Production != value)
                {
                    this.model.Production = value;
                    this.OnPropertyChanged(nameof(Production));
                }
            }
        }

        public string Description
        {
            get
            {
                return this.model.Description;
            }
            set
            {
                if (this.model.Description != value)
                {
                    this.model.Description = value;
                    this.OnPropertyChanged((nameof(Description)));
                }
            }
        }

        public bool CanBuy
        {
            get
            {
                return !this.model.Owned;
            }
            set
            {
                if (this.model.Owned != value)
                {
                    this.model.Owned = value;
                    this.OnPropertyChanged(nameof(CanBuy));
                }
            }
        }

    }
}
