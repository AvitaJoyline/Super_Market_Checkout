using Microsoft.AspNetCore.Mvc;
using SuperMarketCheckout.Service;

namespace SuperMarketCheckout.Controllers
{

        [ApiController]
        [Route("api/[controller]")]
        public class CheckoutController : Controller
        {
            private readonly ICheckout _checkout;

            public CheckoutController(ICheckout checkout)
            {
                _checkout = checkout;
            }

            [HttpPost]
            public IActionResult ScanItem(string sku)
            {
                _checkout.Scan(sku);
                return Ok();
            }
            [HttpGet]
            public IActionResult GetTotal()
            {
                var total = _checkout.GetTotalPrice();
                return Ok(total);
            }
        }
}
