#### Virtual Cash Card Implementation

I have designed and developed only requested features. 

##### Platform 
Visual Studio 2017/2019
.Net Core 2.2 

##### Interfaces

- IVirtualCachCard
  - Withdraw(string pin, double amount);
  - PopUp(double amount);
- IVirtualCashCardController
  - createCard(string cardNumber, double initialBalance, string pin);
  - PopUp(string cardNumber, double amount);
  - Withdraw(string cardNumber, string pin, double amount);
 - IVirtualCashCardRepository
   - GetByCardNumber(string cardNumber);
   - Insert(string cardNumber, IVirtualCashCard virtualCash);

#### Classes

- VirtualCashCard

I have implemented a simple cash card. There is no credit limit or other features.
There is only one way to create a new card is CreateCard factory method. 
The CreateCard method creates a card with CardNumber, Pin and initialBalance. 
CardNumber and Pin are not accessible. Clients have to know CardNumber and Pin o use the virtual card.
Balance is only returning after Popup and Withdraw operations. 
GetBalance method can be added into the interface.

**CreateCard Method**
We have to thinks about this method. I will continue to work in the dev branch. 
This implementation is ok. But if we want to implement a new type of cards this method would be a bottleneck for our solution. ( such as loyalty cards or point cards), 


- VirtualCashCardController

Cash Card is only accessible via VirtualCashCardController.

- VirtualCashCardRepository

I have created a simple in-memory object to store virtual cards. 


#### Unit Test.

* VirtualCardShouldChangeBalanceAfterWithDraw
* VirtualCardShouldChangeBalanceAfterPopup
* VirtualCardShouldReturnFalseAfterWrongPin

#### Console Application

I have created a simple console application see the results.