using Moq;
using SuperMarketCheckout.Models;
using SuperMarketCheckout.Service;
using Xunit;

namespace SuperMarketCheckout.UnitTests;
/// <summary>
/// Unit tests for the Checkout functionality.
/// </summary>
public class CheckoutUnitTests
{
    /// <summary>
    /// Tests the calculation of total price without any offers.
    /// </summary>
    [Fact]
    public void GetTotalNoOffer()
    {
        // Arrange
        var pricingRules = new List<Price>
        {
            new Price { SKU = "A", UnitPrice = 50 },
            new Price { SKU = "B", UnitPrice = 30 },
            new Price { SKU = "C", UnitPrice = 20 }

        };

        var pricingServiceMock = new Mock<IPricing>();
        pricingServiceMock.Setup(x => x.GetUnitPrice("A")).Returns(50);
        pricingServiceMock.Setup(x => x.GetUnitPrice("B")).Returns(30);
        pricingServiceMock.Setup(x => x.GetUnitPrice("C")).Returns(20);
        pricingServiceMock.Setup(x => x.GetOffer("A")).Returns((null, null));
        pricingServiceMock.Setup(x => x.GetOffer("B")).Returns((null, null));
        pricingServiceMock.Setup(x => x.GetOffer("C")).Returns((null, null));


        var checkout = new Checkout(pricingServiceMock.Object);

        // Act
        checkout.Scan("A");
        checkout.Scan("B");
        checkout.Scan("C");
        var total = checkout.GetTotalPrice();

        // Assert
        Assert.Equal(100, total);

    }

    /// <summary>
    /// Tests the calculation of total price with offers applied.
    /// </summary>
    [Fact]
    public void GetTotalWithOffers()
    {
        // Arrange
        var pricingRules = new List<Price>
        {
            new Price { SKU = "A", UnitPrice = 50, Quantity = 3, OfferPrice = 130 },
            new Price { SKU = "B", UnitPrice = 30 }
        };

        var pricingServiceMock = new Mock<IPricing>();
        pricingServiceMock.Setup(x => x.GetUnitPrice("A")).Returns(50);
        pricingServiceMock.Setup(x => x.GetUnitPrice("B")).Returns(30);
        pricingServiceMock.Setup(x => x.GetOffer("A")).Returns((3, 130));
        pricingServiceMock.Setup(x => x.GetOffer("B")).Returns((null, null));

        var checkout = new Checkout(pricingServiceMock.Object);

        // Act
        checkout.Scan("A");
        checkout.Scan("A");
        checkout.Scan("A");
        checkout.Scan("B");
        var total = checkout.GetTotalPrice();

        // Assert
        Assert.Equal(160, total);

    }
}