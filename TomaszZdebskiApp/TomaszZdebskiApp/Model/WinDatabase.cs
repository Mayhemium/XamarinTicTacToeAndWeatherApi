using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace TomaszZdebskiApp.Model
{
    class WinDatabase
    {
        private SQLiteConnection database;
        private static object collisionLock = new object();

        public ObservableCollection<WinData> Wins { get; set; }
        
        public WinDatabase()
        {
            database = new SQLiteConnection(DependencyService.Get<IDatabaseConnection>().DbConnection());
            database?.CreateTable<WinData>();
            Wins = new ObservableCollection<WinData>(database.Table<WinData>());
            if (database.Table<WinData>().Count()==0)
            {
                CreateData();
            }
        }

        private void CreateData()
        {
            Wins.Clear();
            Wins.Add(new WinData()
            {
                Name = "X",
                Wins = 0
            });
            Wins.Add(new WinData()
            {
                Name = "Y",
                Wins = 0
            });
            Wins.Add(new WinData()
            {
                Name = "Tie",
                Wins = 0
            });
            lock (collisionLock)
            {
                database.Insert(Wins[0]);
                database.Insert(Wins[1]);
                database.Insert(Wins[2]);
            }
        }

        public void AddWin(string name)
        {

        }
    }
}
