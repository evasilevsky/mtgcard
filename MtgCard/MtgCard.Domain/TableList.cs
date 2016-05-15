using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtgCard.Domain
{
    public class TableList<T> : List<T>
    {
        public T Left { get; set; }
        public T Right { get; set; }

        public TableList(T left, T right)
        {
            Left = left;
            Right = Right;
        }
    }
}
