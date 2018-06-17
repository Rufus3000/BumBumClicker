using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BumBumClicker.Backend.Models
{
    using SQLite;

    public class Bums
    {
        [PrimaryKey]
        public int Id { get; set; }
        public int BumBums { get; set; }

        public Bums() { }

        public Bums(int bums)
        {
            this.BumBums = bums;
        }
    }
}
