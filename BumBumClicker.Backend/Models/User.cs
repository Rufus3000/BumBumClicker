using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace BumBumClicker.Backend.Models
{
    using System.Data.SqlTypes;

    using SQLitePCL;

    public class User
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }

        public User() { }

        public User(string name, byte[] image)
        {
            this.Name = name;
            this.Image = image;
        }
    }
}
