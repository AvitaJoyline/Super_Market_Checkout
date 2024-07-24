using SuperMarketCheckout.Models;

namespace SuperMarketCheckout.Service
{
    public class Pricing
        {
            private List<Price> _pricing = new List<Price>();

            public void SetPricingRules(IEnumerable<Price> pricingRules)
            {
                _pricing = pricingRules.ToList();
            }

            public int GetUnitPrice(string sku)
            {
                return _pricing.FirstOrDefault(p => p.SKU == sku)?.UnitPrice ?? 0;
            }

            public (int? Quantity, int? Price) GetOffer(string sku)
            {
                var rule = _pricing.FirstOrDefault(p => p.SKU == sku);
                return (rule?.Quantity, rule?.OfferPrice);
            }
    }
}
