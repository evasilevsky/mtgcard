﻿using MtgCard.Domain;
using MtgCard.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MtgCard.App
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
		private CardAdapter cardAdapter;
		private int row = 0;
		private int col = 0;

        public MainPage()
		{
			this.InitializeComponent();
			cardAdapter = new CardAdapter();
			var model = new Card();
			model.copies = 2;
			this.DataContext = model;
        }
		
		public void AddCardToStackPanel(Card card)
		{
			var cardControl = new CardControl(card);
			cardControl.card = card;

			switch (row)
			{
				case 0:
					sp1.Children.Add(cardControl);
					break;
				case 1:
					sp2.Children.Add(cardControl);
					break;
				case 2:
					sp3.Children.Add(cardControl);
					break;
			}

			if (col < 5)
			{
				col++;
			}
			else
			{
				col = 0;
				row++;
			}
		}

		private async void button_Click(object sender, RoutedEventArgs e)
		{
			var card = await cardAdapter.GetCardByName(cardName.Text);

			AddCardToStackPanel(card);
		}

		

		private async void cardName_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
		{
			var cards = await cardAdapter.GetTypeAhead(cardName.Text);
			((AutoSuggestBox)sender).ItemsSource = cards.Select(x => x.id);
		}

		private async void cardName_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
		{
			//var card = await cardAdapter.GetCardByName(args.QueryText);

			//AddImageToStackPanel(card.DefaultImage);
		}

		private async void cardName_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
		{

			var card = await cardAdapter.GetCardByName(args.SelectedItem.ToString());

			AddCardToStackPanel(card);
		}
	}
}
