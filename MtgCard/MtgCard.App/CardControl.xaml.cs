using MtgCard.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace MtgCard.App
{
	public sealed partial class CardControl : UserControl
	{
		private Card card;
		public Action Delete;

		public CardControl()
		{
			this.InitializeComponent();
			card = new Card();
			card.copies = 2;
			card.editions = new List<Edition> { new Edition { image_Url= "https://image.deckbrew.com/mtg/multiverseid/382943.jpg" } };
			image.Source = new BitmapImage(new Uri(card.DefaultImage, UriKind.Absolute));
			this.DataContext = this;
		}

		private void addCopy_Click(object sender, RoutedEventArgs e)
		{
			if (!removeCopy.IsEnabled)
			{
				removeCopy.IsEnabled = true;
				image.Opacity = 1;
			}
			card.copies++;
			copies.Text = card.copies.ToString();
		}

		private void removeCopy_Click(object sender, RoutedEventArgs e)
		{
			card.copies--;
			if (card.copies == 0)
			{
				image.Opacity = .2;
				removeCopy.IsEnabled = false;
			}
			else
			{
				image.Opacity = 1;
			}
			copies.Text = card.copies.ToString();
		}
	}
}
