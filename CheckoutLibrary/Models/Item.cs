namespace CheckoutLibrary.Models
{
    public class Item
    { 
        // Declare Sku Property
        public string Sku { get; set; }
        // Declare UnitPrice Property
        public decimal UnitPrice { get; set; }

        // Constructor of Item Class
        public Item(string sku, decimal unitPrice)
        {
            Sku = sku;
            UnitPrice = unitPrice;
        }
    }
}
