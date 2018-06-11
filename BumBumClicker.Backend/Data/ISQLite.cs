using System;
using System.Collections.Generic;
using System.Text;

namespace BumBumClicker.Data
{
    using SQLite;

    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
