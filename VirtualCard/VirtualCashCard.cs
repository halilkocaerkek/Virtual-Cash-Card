using System.Threading;
using VirtualCard.Interfaces;

namespace VirtualCard
{
    public class VirtualCashCard : IVirtualCashCard
    {
        private string CardNumber;
        private double Balance;
        private string Pin;

        private readonly object _Lock = new object();

        private VirtualCashCard() { }
        public static IVirtualCashCard createCard(string cardNumber, string pin, double initialBalance)
        {
            return new VirtualCashCard()
            {
                CardNumber = cardNumber,
                Pin = pin,
                Balance = initialBalance
            };
        }

        public (bool result, double balance) PopUp(double amount)
        {
            return ApplyAmount(amount);
        }

        public (bool result, double balance) Withdraw(string pin, double amount)
        {
            if (this.Pin.Equals(pin))
            {
                return ApplyAmount(amount * -1);
            }
            else return (false, this.Balance);
        }

        private (bool result, double balance) ApplyAmount(double amount)
        {
            var result = true;
            var returnBalance = Balance;
            if (Monitor.TryEnter(_Lock, 100))
            {
                try
                {
                    Balance += amount;
                    returnBalance = Balance;
                }
                finally
                {
                    Monitor.Exit(_Lock);
                }
            }  
            else
            {
                result = false;
            }
            return (result, returnBalance);
        }
    }
}
