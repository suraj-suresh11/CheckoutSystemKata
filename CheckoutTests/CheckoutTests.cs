using CheckoutLibrary;
using CheckoutLibrary.Models;
using Xunit;

namespace CheckoutTests
{
    public class CheckoutTests
    {
        [Fact]
        public void Can_Scan_Item()
        {
            var checkout = new Checkout();
            var item = new Item("A99", 0.50m);

            checkout.Scan(item);

            Assert.Equal(0.50m, checkout.Total());
        }

        [Fact]
        public void All_Items()
        {
            var checkout = new Checkout();
            checkout.Scan(new Item("A99", 0.50m));
            checkout.Scan(new Item("B15", 0.30m));
            checkout.Scan(new Item("C40", 0.60m));

            Assert.Equal(1.40m, checkout.Total());
        }

        [Fact]
        public void Total_Considers_Special_Offers_A99()
        {
            var checkout = new Checkout();
            checkout.Scan(new Item("A99", 0.50m));
            checkout.Scan(new Item("A99", 0.50m));
            checkout.Scan(new Item("A99", 0.50m));

            Assert.Equal(1.30m, checkout.Total());
        }

        [Fact]
        public void Total_Considers_Special_Offers_B15()
        {
            var checkout = new Checkout();
            checkout.Scan(new Item("B15", 0.30m));
            checkout.Scan(new Item("B15", 0.30m));
            Assert.Equal(0.45m, checkout.Total());
        }

        [Fact]
        public void Total_Considers_Multiple_Offers_And_Regular_Items()
        {
            var checkout = new Checkout();
            checkout.Scan(new Item("A99", 0.50m));
            checkout.Scan(new Item("B15", 0.30m));
            checkout.Scan(new Item("C40", 0.60m));
            checkout.Scan(new Item("B15", 0.30m));
            checkout.Scan(new Item("A99", 0.50m));
            checkout.Scan(new Item("A99", 0.50m));

            Assert.Equal(2.35m, checkout.Total());
        }
    }
}
