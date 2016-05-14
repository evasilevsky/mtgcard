using System.Collections.Generic;

namespace MtgCard.Domain
{
    public class Block
    {
        public List<Set> Sets { get; set; }
        public string Name { get; set; }
        public SetId PrimarySet { get; set; }
    }
}
