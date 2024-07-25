using SuperMarketCheckout.Models;

namespace SuperMarketCheckout.Service
{
    public interface IPricing
    {
        int GetUnitPrice(string sku);
        (int? Quantity, int? Price) GetOffer(string sku);
    }
}
