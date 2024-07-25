using Microsoft.AspNetCore.Mvc;
using SuperMarketCheckout.Service;

namespace SuperMarketCheckout.Controllers
{

        [ApiController]
        [Route("api/[controller]")]
        public class CheckoutController : Controller
        {
            private readonly ICheckout _checkout;

        /// <summary>
        /// Initializes a new instance of the <see cref="CheckoutController"/> class.
        /// </summary>
        /// <param name="checkout">The checkout service to use.</param>
        public CheckoutController(ICheckout checkout)
            {
                _checkout = checkout;
            }

        /// <summary>
        /// Scans an item by its SKU.
        /// </summary>
        /// <param name="sku">The SKU of the item to scan.</param>
        /// <returns>HTTP status code indicating the result of the operation.</returns>
        [HttpPost]
            public IActionResult ScanItem(string sku)
            {
                _checkout.Scan(sku);
                return Ok();
            }

        /// <summary>
        /// Gets the total price of all scanned items.
        /// </summary>
        /// <returns>The total price.</returns>
        [HttpGet]
            public IActionResult GetTotal()
            {
                var total = _checkout.GetTotalPrice();
                return Ok(total);
            }
        }
}
