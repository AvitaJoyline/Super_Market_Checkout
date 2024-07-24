using SuperMarketCheckout.Models;

namespace SuperMarketCheckout.Service
{
    public interface IPricing
    {
        void SetPricingRules(IEnumerable<Price> pricingRules);
        int GetUnitPrice(string sku);
        (int? Quantity, int? Price) GetOffer(string sku);
    }
}
