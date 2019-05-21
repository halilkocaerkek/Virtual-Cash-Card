namespace VirtualCard.Interfaces
{
    public interface IVirtualCashCardRepository
    { 
        IVirtualCashCard GetByCardNumber(string cardNumber);
        bool Add(string cardNumber, IVirtualCashCard virtualCash); 
    }
}
