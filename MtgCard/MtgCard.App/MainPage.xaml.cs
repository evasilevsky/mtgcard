using MtgCard.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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
        }

		public void AddImageToGrid(string imageUrl)
		{
			var img = new Image();
			img.Width = 100;
			img.Height = 100;
			img.Source = new BitmapImage(new Uri(imageUrl, UriKind.Absolute));
			Grid.SetRow(img, row);
			Grid.SetColumn(img, col);
			if (row < field.RowDefinitions.Count)
			{
				row++;
			}
			else if (col < field.ColumnDefinitions.Count)
			{
				col++;
				row = 0;
			}
			field.Children.Add(img);
		}
		public void AddImageToStackPanel(string imageUrl)
		{
			var img = new Image();
			img.Width = 100;
			img.Height = 100;
			img.Source = new BitmapImage(new Uri(imageUrl, UriKind.Absolute));
			
			switch (row)
			{
				case 0:
					sp1.Children.Add(img);
					break;
				case 1:
					sp2.Children.Add(img);
					break;
				case 2:
					sp3.Children.Add(img);
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

			AddImageToStackPanel(card.DefaultImage);
		}
	}
}
