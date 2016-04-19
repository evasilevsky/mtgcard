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
			this.DataContext = this;
		}

		private void addCopy_Click(object sender, RoutedEventArgs e)
		{
			card.copies++;
		}

		private void removeCopy_Click(object sender, RoutedEventArgs e)
		{
			card.copies--;
			if (card.copies == 0)
			{
				Delete?.Invoke();
			}
		}
	}
}
