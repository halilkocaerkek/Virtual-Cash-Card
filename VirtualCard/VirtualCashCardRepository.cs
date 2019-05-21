using System.Collections.Concurrent;
using VirtualCard.Interfaces;

namespace VirtualCard
{
    public class VirtualCashCardRepository : IVirtualCashCardRepository
    {
        private ConcurrentDictionary<string, IVirtualCashCard> cardList = new ConcurrentDictionary<string, IVirtualCashCard>();

        public IVirtualCashCard GetByCardNumber(string cardNumber)
        {
            IVirtualCashCard result = null;
            cardList.TryGetValue(cardNumber, out result);     
            return result;
        }

        public bool Add(string cardNumber, IVirtualCashCard virtualCashCard)
        {            
            return cardList.TryAdd(cardNumber, virtualCashCard); ;
        } 

    }
}
