namespace CheckoutLibrary.Models
{
    public class SpecialOffer
    {
        // Declare Sku Property
        public string Sku { get; set; }
        // Declare Quantity Property
        public int Quantity { get; set; }
        // Declare OfferPrice Property
        public decimal OfferPrice { get; set; }

        // Constructor of SpecialOffer Class
        public SpecialOffer(string sku, int quantity, decimal offerPrice)
        {
            Sku = sku;
            Quantity = quantity;
            OfferPrice = offerPrice;
        }
    }
}
