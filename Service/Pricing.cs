using SuperMarketCheckout.Models;

namespace SuperMarketCheckout.Service
{
    public class Pricing
        {
            private List<Price> _pricing = new List<Price>();

        /// <summary>
        /// Gets the unit price of a product by its SKU.
        /// </summary>
        /// <param name="sku">The SKU of the product.</param>
        /// <returns>The unit price.</returns>
        public int GetUnitPrice(string sku)
            {
                return _pricing.FirstOrDefault(p => p.SKU == sku)?.UnitPrice ?? 0;
            }
        /// <summary>
        /// Gets the offer details for a product by its SKU.
        /// </summary>
        /// <param name="sku">The SKU of the product.</param>
        /// <returns>The offer details (quantity and price).</returns>
        public (int? Quantity, int? Price) GetOffer(string sku)
            {
                var rule = _pricing.FirstOrDefault(p => p.SKU == sku);
                return (rule?.Quantity, rule?.OfferPrice);
            }
    }
}
