namespace VirtualCard.Interfaces
{
    public interface IVirtualCashCard
    {
        (bool result, double balance) Withdraw(string pin, double amount);
        (bool result, double balance) PopUp(double amount);
    }
}
