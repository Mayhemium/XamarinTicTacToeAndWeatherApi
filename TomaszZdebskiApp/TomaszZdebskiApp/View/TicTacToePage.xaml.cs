﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomaszZdebskiApp.Model;
using TomaszZdebskiApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TomaszZdebskiApp.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TicTacToePage : ContentPage
	{

		public TicTacToePage ()
		{
			InitializeComponent ();
            BindingContext = new TicTacToePageViewModel(mainGrid);
            
		}
	}
}