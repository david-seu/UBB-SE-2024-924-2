using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISSLab.Model.Entities;

namespace Tests.Model
{
    internal class FixedPriceMarketplacePostTests
    {
        private FixedPriceMarketplacePost fixedPriceMarketplacePost;

        [SetUp]
        public void SetUp()
        {
            fixedPriceMarketplacePost = new FixedPriceMarketplacePost();
        }

        [Test]
        public void Price_Any_UpdatesPrice()
        {
            fixedPriceMarketplacePost.Price = 11.5f;

            Assert.That(fixedPriceMarketplacePost.Price, Is.EqualTo(11.5f));
        }

        [Test]
        public void ExpirationDate_Any_UpdatesExpirationDate()
        {
            fixedPriceMarketplacePost.ExpirationDate = new DateTime(2015, 12, 31);

            Assert.That(fixedPriceMarketplacePost.ExpirationDate.ToString(), Is.EqualTo("31.12.2015 00:00:00"));
        }

        [Test]
        public void Delivery_Any_UpdatesDelivery()
        {
            fixedPriceMarketplacePost.Delivery = "A";

            Assert.That(fixedPriceMarketplacePost.Delivery, Is.EqualTo("A"));
        }

        [Test]
        public void BuyProduct_ProductAlreadyBought_ExceptionThrown()
        {
            Guid guidOfBuyer = Guid.NewGuid();
            fixedPriceMarketplacePost.BuyerId = guidOfBuyer;

            var exceptionMessage = Assert.Throws<Exception>(() => { fixedPriceMarketplacePost.BuyProduct(guidOfBuyer); });
            Assert.That(exceptionMessage.Message, Is.EqualTo("Product already bought"));
        }

        [Test]
        public void BuyProduct_ProductNotAlreadyBought_BuyerIdIsUpdated()
        {
            Guid guidOfBuyer = Guid.Empty;
            fixedPriceMarketplacePost.BuyProduct(guidOfBuyer);

            Assert.That(fixedPriceMarketplacePost.BuyerId, Is.EqualTo(guidOfBuyer));
        }
    }
}
