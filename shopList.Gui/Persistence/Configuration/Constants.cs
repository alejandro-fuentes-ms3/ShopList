using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopList.Gui.Persistence.Configuration
{
    public static class Constants
    {
        public static string DataBasePath => 
            Path.Combine
             (FileSystem.AppDataDirectory,
             DatabaseFileName
            );
       
        public const string DatabaseFileName = "Shoplist.db3";
       
        public const SQLite.SQLiteOpenFlags Flags =
            SQLite.SQLiteOpenFlags.ReadWrite |
             SQLite.SQLiteOpenFlags.Create |
             SQLite.SQLiteOpenFlags.SharedCache;
    }
}
