﻿namespace SuperMarketCheckout.Service
{
    public class Checkout : ICheckout
    {
        Dictionary<string, int> _items = new Dictionary<string, int>();
        private readonly IPricing _pricing;

        /// <summary>
        /// Scans an item by its SKU.
        /// </summary>
        /// <param name="item">The SKU of the item.</param>
        public Checkout(IPricing pricing)
        {
            _pricing = pricing;
            _items = new Dictionary<string, int>();
        }

        /// <summary>
        /// Gets the total price of all scanned items.
        /// </summary>
        /// <returns>The total price.</returns>
        public int GetTotalPrice()
        {
            int total = 0;

            foreach (var item in _items)
            {
                var sku = item.Key;
                var quantity = item.Value;
                var unitPrice = _pricing.GetUnitPrice(sku);
                var (offerQuantity, offerPrice) = _pricing.GetOffer(sku);

                if (offerQuantity.HasValue && quantity >= offerQuantity.Value)
                {
                    total += (quantity / offerQuantity.Value) * offerPrice.Value;
                    total += (quantity % offerQuantity.Value) * unitPrice;
                }
                else
                {
                    total += quantity * unitPrice;
                }
            }

            return total;
        }

        public void Scan(string item)
        {
            if (_items.ContainsKey(item))
            {
                _items[item]++;
            }
            else
            {
                _items[item] = 1;
            }
        }


    }
}
