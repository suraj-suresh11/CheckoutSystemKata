using System.Collections.Generic;
using System.Linq;
using CheckoutLibrary.Models;

namespace CheckoutLibrary
{
    public class Checkout
    {
        // Declare Private properties
        private readonly List<Item> _scannedItems = new();
        private readonly Dictionary<string, (int Quantity, decimal OfferPrice)> _offers = new();

        public Checkout()
        {
            // Initialize special offers
            _offers["A99"] = (3, 1.30m);
            _offers["B15"] = (2, 0.45m);
        }

        // Scan Method which adds items to the list
        public void Scan(Item item)
        {
            _scannedItems.Add(item);
        }

        // Total method which calculates the total 
        public decimal Total()
        {
            var groupedItems = _scannedItems
                .GroupBy(item => item.Sku)
                .ToDictionary(g => g.Key, g => g.ToList());

            decimal total = 0;

            foreach (var group in groupedItems)
            {
                string sku = group.Key;
                var items = group.Value;
                int count = items.Count;

                if (_offers.TryGetValue(sku, out var offer))
                {
                    int offerQuantity = offer.Quantity;
                    decimal offerPrice = offer.OfferPrice;

                    // Calculate total for the group with offers
                    int offerSets = count / offerQuantity;
                    int remainingItems = count % offerQuantity;

                    total += (offerSets * offerPrice) + (remainingItems * items[0].UnitPrice);
                }
                else
                {
                    // No offer, regular pricing
                    total += count * items[0].UnitPrice;
                }
            }

            return total;
        }
    }
}