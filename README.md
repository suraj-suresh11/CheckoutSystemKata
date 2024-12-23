The checkoutsystem is working properly. It also considers the special offer criteria that is A99 is scanned thrice(in different order as well) the price would be 1.30 instead of 1.50 and
if B15 is scanned twice the price is 0.45 instead of 0.60. 

## Refactoring the code
Code can be refactored by splitting the Total() method in Checkout class with 3 more smaller methods such as
  <ul>
  <li> ApplyOffer(): Handle applying offers for a specific SKU.
  CalculateRegularPrice(): Calculate the price for items without any offers.
  CalculateTotalForGroup(): A helper method to calculate the total for a specific group of items.</li>
    
  The code can be refactored further more to comply by the Single Responsibility Principle(SRP). The Checkout class can also be split into
  <li> OfferService: A class to handle all logic related to special offers.
  Checkout: The main class for scanning items and calculating the total, delegating offer-related logic to OfferService. </li></ul>
<br>
By doing the above, the code can be more scalable, testable and maintainable. In future, if we want to add new offers we can add them in offerservice class without wanting to change anything 
in Checkout class and it promotes seperation of concerns.
