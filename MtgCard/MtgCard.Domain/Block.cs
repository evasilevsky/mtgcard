using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtgCard.Domain
{
    public class Block
    {
        public List<Set> Sets { get; set; }
        public string Name { get; set; }
        public SetId PrimarySet { get; set; }
    }
}
