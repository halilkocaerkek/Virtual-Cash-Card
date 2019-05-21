namespace VirtualCard.Interfaces
{
    public interface IVirtualCashCardController
    {
        void createCard(string cardNumber, double initialBalance, string pin);
        (bool result, double balance) PopUp(string cardNumber, double amount);
        (bool result, double balance) Withdraw(string cardNumber, string pin, double amount);

    }
}
