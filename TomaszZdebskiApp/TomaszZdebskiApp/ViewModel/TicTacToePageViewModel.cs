using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TomaszZdebskiApp.Model;
using Xamarin.Forms;
using System.Linq;

namespace TomaszZdebskiApp.ViewModel
{
    public class TicTacToePageViewModel : BaseViewModel
    {
        private SQLiteConnection database;
        private static object collisionLock = new object();

        public ObservableCollection<WinData> Wins { get; set; }
        
        Grid grid;
        bool gameOn;
        int moves;

        public bool MenuVisible { get { return !gameOn; } }

        public string[] players { get { return new string[] { "X", "O" }; } }
        private string _test;
        public string Test
        {
            get
            {
                return _test;
            }
            set
            {
                _test = value;
                RaisePropertyChanged(nameof(Test));
            }
        }

        private string _btn0;
        public string Btn0
        {
            get
            {
                return _btn0;
            }
            set
            {
                _btn0 = value;
                RaisePropertyChanged(nameof(Btn0));
            }
        }

        private string _btn1;
        public string Btn1
        {
            get
            {
                return _btn1;
            }
            set
            {
                _btn1 = value;
                RaisePropertyChanged(nameof(Btn1));
            }
        }

        private string _btn2;
        public string Btn2
        {
            get
            {
                return _btn2;
            }
            set
            {
                _btn2 = value;
                RaisePropertyChanged(nameof(Btn2));
            }
        }

        private string _btn3;
        public string Btn3
        {
            get
            {
                return _btn3;
            }
            set
            {
                _btn3 = value;
                RaisePropertyChanged(nameof(Btn3));
            }
        }

        private string _btn4;
        public string Btn4
        {
            get
            {
                return _btn4;
            }
            set
            {
                _btn4 = value;
                RaisePropertyChanged(nameof(Btn4));
            }
        }

        private string _btn5;
        public string Btn5
        {
            get
            {
                return _btn5;
            }
            set
            {
                _btn5 = value;
                RaisePropertyChanged(nameof(Btn5));
            }
        }

        private string _btn6;
        public string Btn6
        {
            get
            {
                return _btn6;
            }
            set
            {
                _btn6 = value;
                RaisePropertyChanged(nameof(Btn6));
            }
        }

        private string _btn7;
        public string Btn7
        {
            get
            {
                return _btn7;
            }
            set
            {
                _btn7 = value;
                RaisePropertyChanged(nameof(Btn7));
            }
        }

        private string _btn8;
        public string Btn8
        {
            get
            {
                return _btn8;
            }
            set
            {
                _btn8 = value;
                RaisePropertyChanged(nameof(Btn8));
            }
        }

        private string _current;
        public string Current
        {
            get
            {
                return _current;
            }
            set
            {
                _current = value;
                RaisePropertyChanged(nameof(Current));
            }
        }

        private string _game;
        public string GameText
        {
            get
            {
                return _game;
            }
            set
            {
                _game = value;
                RaisePropertyChanged(nameof(GameText));
            }
        }
        public Command BtnClick { get; private set; }
        public Command StartClick { get; private set; }

        public TicTacToePageViewModel(Grid grid)
        {
            this.grid = grid;
            BtnClick = new Command<string>((i)=>MyClick(i));
            StartClick = new Command(StartGame);
            Current = "X";
            gameOn = false;

            Restart();


            database = new SQLiteConnection(DependencyService.Get<IDatabaseConnection>().DbConnection());
            database?.CreateTable<WinData>();
            Wins = new ObservableCollection<WinData>(database.Table<WinData>());
            
            if (database.Table<WinData>().Count() == 0)
            {
                CreateData();
            }
        }

        private void StartGame()
        {
            Restart();
            gameOn = true;
            RaisePropertyChanged(nameof(MenuVisible));
        }

        private void Restart()
        {
            GameText = "";
            Btn0 = "";
            Btn1 = "";
            Btn2 = "";
            Btn3 = "";
            Btn4 = "";
            Btn5 = "";
            Btn6 = "";
            Btn7 = "";
            Btn8 = "";
            moves = 0;
            foreach (Button b in grid.Children)
            {
                b.BackgroundColor = Color.Default;
            }
        }

        private void MyClick(string s)
        {
            if (!gameOn)
                return;
            int i = int.Parse(s);
            if (GetTile(i) != "")
                return;
            SetTile(i,Current);
            if (Current == "X")
                Current = "O";
            else
                Current = "X";
            moves++;

            if (Check())
                return;

            if (moves == 9)
                Tie();
        }

        private bool Check()
        {
            if (CheckThree(0, 1, 2))
                return true;
            if (CheckThree(3, 4, 5))
                return true;
            if (CheckThree(6, 7, 8))
                return true;
            if (CheckThree(0, 3, 6))
                return true;
            if (CheckThree(1, 4, 7))
                return true;
            if (CheckThree(2, 5, 8))
                return true;
            if (CheckThree(0, 4, 8))
                return true;
            if (CheckThree(2, 4, 6))
                return true;
            return false;
        }

        private bool CheckThree(int one, int two, int three)
        {
            if(GetTile(one) == GetTile(two) && GetTile(two) == GetTile(three) && GetTile(three) != "")
            {
                grid.Children[one].BackgroundColor = Color.LightGreen;
                grid.Children[two].BackgroundColor = Color.LightGreen;
                grid.Children[three].BackgroundColor = Color.LightGreen;
                GameWon(GetTile(one));
                return true;
            }
            return false;
        }

        private void GameWon(string s)
        {
            gameOn = false;
            RaisePropertyChanged(nameof(MenuVisible));
            GameText = s + " won";
            AddWin(s);
        }

        private void Tie()
        {
            gameOn = false;
            RaisePropertyChanged(nameof(MenuVisible));
            GameText = "Game Tied";
            AddWin("Tie");
        }

        private string GetTile(int i)
        {
            switch (i)
            {
                case 0:
                    return Btn0;
                case 1:
                    return Btn1;
                case 2:
                    return Btn2;
                case 3:
                    return Btn3;
                case 4:
                    return Btn4;
                case 5:
                    return Btn5;
                case 6:
                    return Btn6;
                case 7:
                    return Btn7;
                case 8:
                    return Btn8;
            }
            throw new IndexOutOfRangeException();
        }
        private void SetTile(int i, string text)
        {
            switch (i)
            {
                case 0:
                    Btn0 = text;
                    break;
                case 1:
                    Btn1 = text;
                    break;
                case 2:
                    Btn2 = text;
                    break;
                case 3:
                    Btn3 = text;
                    break;
                case 4:
                    Btn4 = text;
                    break;
                case 5:
                    Btn5 = text;
                    break;
                case 6:
                    Btn6 = text;
                    break;
                case 7:
                    Btn7 = text;
                    break;
                case 8:
                    Btn8 = text;
                    break;
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
                Name = "O",
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
            WinData d = Wins.FirstOrDefault(x=>x.Name==name);
            d.Wins++;

            lock (collisionLock)
            {
                database.Update(d);
            }
        }
    }
}
