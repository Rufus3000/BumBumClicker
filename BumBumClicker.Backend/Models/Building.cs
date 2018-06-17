using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace BumBumClicker.Backend.Models
{
    

    public class Building
    {
        [PrimaryKey][AutoIncrement]
        public int Id { get; set; }

        public string Title { get; set; }

        public int Price { get; set; }

        public int Production { get; set; }

        public string Description { get; set; }

        public bool Owned { get; set; }

        public Building() { }

        public Building(string title, int price, int production, string description, bool owned)
        {
            this.Title = title;
            this.Price = price;
            this.Production = production;
            this.Description = description;
            this.Owned = owned;
        }
    }
}
