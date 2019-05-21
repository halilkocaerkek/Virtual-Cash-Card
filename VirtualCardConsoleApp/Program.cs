using System;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;
using VirtualCard;

namespace VirtualCardConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var repository = new VirtualCashCardRepository();
            var logger = new Logger();

            var Tasks = new Task[] {
                new Task(() => NewMethod(repository, logger, "1111")),
                new Task(() => NewMethod(repository, logger, "2222")),
                new Task(() => NewMethod(repository, logger, "3333"))
            };

            Tasks.ToList().ForEach(o => o.Start());

            Task.WaitAll(Tasks);

            Console.WriteLine("");
        }

        private static void NewMethod(VirtualCashCardRepository repository, Logger logger, string name)
        {
            var controller1 = new VirtualCashCardController();
            controller1.setRepository(repository);
            controller1.setLogger(logger);
            controller1.setName(name);

            for (int i = 0; i < 10; i++)
            {
                var cardNumber = i.ToString();
                var pin = "1234";

                controller1.createCard(cardNumber, 68, pin);

                controller1.PopUp(cardNumber, 100);
                controller1.Withdraw(cardNumber, pin, 32);
                controller1.Withdraw(cardNumber, pin, 10);

                controller1.Withdraw(cardNumber, "8888", 75);
                controller1.Withdraw(cardNumber, pin, 75);
                controller1.PopUp(cardNumber, 170);
            }

        }
    }
}
