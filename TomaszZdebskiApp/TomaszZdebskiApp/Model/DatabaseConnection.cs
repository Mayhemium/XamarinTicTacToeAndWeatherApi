using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TomaszZdebskiApp.Model
{
    class DatabaseConnection : IDatabaseConnection
    {
        public string DbConnection()
        {
            var dbName = "WinDb.db3";
            var path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), dbName);
            return path;
        }
    }
}
