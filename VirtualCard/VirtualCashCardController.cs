using VirtualCard.Interfaces;

namespace VirtualCard
{
    public class VirtualCashCardController : IVirtualCashCardController
    {
        private IVirtualCashCardRepository _repository;
        private object _lockRepository = new object();
        private ILogger _logger;
        private string _name;

        public void setRepository(VirtualCashCardRepository repository) => this._repository = repository;
        public void setLogger(Logger logger) => this._logger = logger;
        public void setName(string name) => this._name = name;

        public void createCard(string cardNumber, double initialBalance, string pin)
        {
            var card = VirtualCashCard.createCard(cardNumber, pin, initialBalance);
            if (_repository.Add(cardNumber, card))
            {
                _logger.Write(_name, $"Card Number : {cardNumber}, Initialized.");
            }
            else
            {
                _logger.Write(_name, $"Card Number : {cardNumber}, Exist, Not Initialized.");
             }
        }        

        public (bool result, double balance) PopUp(string cardNumber, double amount)
        {
            var card = _repository.GetByCardNumber(cardNumber);
            (var result, var currentBalance) = card.PopUp(amount);
            _logger.Write(_name, $"Card Number : {cardNumber}, PopUp:{amount}, Balance:{currentBalance}, Result: {result}");

            return (result, currentBalance);
        }

        public (bool result, double balance) Withdraw(string cardNumber, string pin, double amount)
        {
            var card = _repository.GetByCardNumber(cardNumber);
            (var result, var currentBalance) = card.Withdraw(pin, amount);
            _logger.Write(_name, $"Card Number : {cardNumber}, Withdraw:{amount}, Balance:{currentBalance}, Result: {result}");

            return (result, currentBalance);
        }
    }
}
