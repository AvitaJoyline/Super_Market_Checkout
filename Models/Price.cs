namespace SuperMarketCheckout.Models
{
    public class Price
    {
        public string SKU { get; set; }
        public int UnitPrice { get; set; }
        public int? Quantity { get; set; }
        public int? OfferPrice { get; set; }
    }
}
