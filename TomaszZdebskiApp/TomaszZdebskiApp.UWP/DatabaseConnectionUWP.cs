using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomaszZdebskiApp.Model;
using Windows.Storage;

namespace TomaszZdebskiApp.UWP
{
    class DatabaseConnectionUWP : IDatabaseConnection
    {
        public string DbConnection()
        {
            var dbName = "WinDb.db3";
            var path = Path.Combine(ApplicationData.Current.LocalFolder.Path, dbName);
            return path;
        }
    }
}
