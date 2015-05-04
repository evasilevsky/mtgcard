using System.Collections.Generic;

namespace MtgCard.Models
{
	public class CircularList<T> : List<T>
	{
		public List<T> List { get; set; }
		public new T this[int i]
		{
			get { return List[i % List.Count]; }
			set { List[i % List.Count] = value; }
		}
	}
}