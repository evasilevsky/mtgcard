using System.Collections.Generic;
using MtgCard.Domain;

namespace MtgCard.Services
{
    public interface IPackFactory
    {
        Pack Build(List<string> cardNames);
        Pack Build(List<Card> cards);
        Pack BuildRandomPackFromSet(string setName, bool packShouldContainFoil = false, bool packShouldContainMythic = false);
    }
}