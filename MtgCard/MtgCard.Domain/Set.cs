using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtgCard.Domain
{
    public class Set
    {
        public SetId Id { get; set; }
        public string Name { get; set; }
        public int NumCards { get; set; }
    }
}
