using Microsoft.VisualStudio.TestTools.UnitTesting;
using VirtualCard;
using VirtualCard.Interfaces;

namespace UnitTestProject1
{
    [TestClass]
    public class VirtualCardTests
    {
        [TestMethod]
        public void VirtualCardShouldChangeBalanceAfterWithDraw()
        {
            double initialBalance = 10;
            double expectedBalance = 0;
            string pin = "1234";

            IVirtualCashCard card = VirtualCashCard.createCard("Card1", pin , initialBalance);
            (var result, var balance) = card.Withdraw ( pin, 10);
            Assert.IsTrue(result);
            Assert.AreEqual(expectedBalance, balance);
        }

        [TestMethod]
        public void VirtualCardShouldChangeBalanceAfterPopup()
        {
            double initialBalance = 10;
            double expectedBalance = 20;
            string pin = "1234";

            IVirtualCashCard card = VirtualCashCard.createCard("Card1", pin, initialBalance);
            (var result, var balance) = card.PopUp(10);
            Assert.AreEqual(expectedBalance, balance);
        }

        [TestMethod]
        public void VirtualCardShouldReturnFalseAfterWrongPin()
        {
            double initialBalance = 10;
            string pin = "1234";

            IVirtualCashCard card = VirtualCashCard.createCard("Card1", pin, initialBalance);
            (var result, var balance) = card.Withdraw("8888", 10);
            Assert.IsFalse(result);
  
        }
    }
}
