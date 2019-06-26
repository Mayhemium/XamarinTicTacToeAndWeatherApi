using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TomaszZdebskiApp.Model
{
    [Table("WinData")]
    public class WinData : INotifyPropertyChanged
    {
        private int _id;
        [PrimaryKey, AutoIncrement]

        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                this._id = value;
                OnPropertyChanged(nameof(Id));
            }
        }



        private string _name;


        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                this._name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private int _wins;


        public int Wins
        {
            get
            {
                return _wins;
            }
            set
            {
                this._wins = value;
                OnPropertyChanged(nameof(Wins));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
