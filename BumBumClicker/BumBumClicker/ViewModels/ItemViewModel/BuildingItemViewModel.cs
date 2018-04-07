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

        public string Title
        {
            get
            {
                return this.model.Title;
            }
            set
            {
                if (this.model.Title != value)
                {
                    this.model.Title = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public string Subtitle
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
                    this.OnPropertyChanged(nameof(this.Subtitle));
                }
            }
        }
    }
}
