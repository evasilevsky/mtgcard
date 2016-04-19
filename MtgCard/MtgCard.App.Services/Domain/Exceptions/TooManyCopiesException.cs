using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtgCard.Domain.Exceptions
{
	public class TooManyCopiesException : Exception
	{
		public TooManyCopiesException (string message) : base(message)
		{

		}
	}
}
