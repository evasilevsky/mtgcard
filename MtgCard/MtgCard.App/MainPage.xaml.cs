using MtgCard.Domain;
using MtgCard.Services;
using System.Collections.Generic;
using System.Linq;
using Windows.ApplicationModel.DataTransfer;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MtgCard.App
{
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
			format.ItemsSource = new List<string>
			{
				"Modern", 
				"Legacy", 
				"Vintage", 
				"Commander"
			};
			this.DataContext = model;
        }
		
		public void AddCardToStackPanel(Card card)
		{
			var cardControl = new CardControl(card);
			card.copies = 1;
			cardControl.CanDrag = true;
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
			var card = await cardAdapter.GetCardByName(args.QueryText);

			AddCardToStackPanel(card);
		}

		private async void cardName_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
		{

			//var card = await cardAdapter.GetCardByName(args.SelectedItem.ToString());

			//AddCardToStackPanel(card);
		}

		private void MainBoard_DragOver(object sender, DragEventArgs e)
		{
			e.AcceptedOperation = DataPackageOperation.Copy;
		}

		private void SideBoard_DragOver(object sender, DragEventArgs e)
		{
			e.AcceptedOperation = DataPackageOperation.Copy;
		}

		private async void MainBoard_Drop(object sender, DragEventArgs e)
		{
		}

		private void SideBoard_Drop(object sender, DragEventArgs e)
		{

		}
	}
}
