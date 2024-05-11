using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISSLab.Model.Entities;

namespace Tests.Model
{
    internal class FixedPricePostTests
    {
        private FixedPricePost fixedPricePost;

        [SetUp]
        public void SetUp()
        {
            fixedPricePost = new FixedPricePost();
        }

        [Test]
        public void Price_Any_UpdatesPrice()
        {
            fixedPricePost.Price = 11.5f;

            Assert.That(fixedPricePost.Price, Is.EqualTo(11.5f));
        }

        [Test]
        public void ExpirationDate_Any_UpdatesExpirationDate()
        {
            fixedPricePost.ExpirationDate = new DateTime(2015, 12, 31);

            Assert.That(fixedPricePost.ExpirationDate.ToString(), Is.EqualTo("31.12.2015 00:00:00"));
        }

        [Test]
        public void Delivery_Any_UpdatesDelivery()
        {
            fixedPricePost.Delivery = "A";

            Assert.That(fixedPricePost.Delivery, Is.EqualTo("A"));
        }

        [Test]
        public void BuyProduct_ProductAlreadyBought_ExceptionThrown()
        {
            Guid guidOfBuyer = Guid.NewGuid();
            fixedPricePost.BuyerId = guidOfBuyer;

            var exceptionMessage = Assert.Throws<Exception>(() => { fixedPricePost.BuyProduct(guidOfBuyer); });
            Assert.That(exceptionMessage.Message, Is.EqualTo("Product already bought"));
        }

        [Test]
        public void BuyProduct_ProductNotAlreadyBought_BuyerIdIsUpdated()
        {
            Guid guidOfBuyer = Guid.Empty;
            fixedPricePost.BuyProduct(guidOfBuyer);

            Assert.That(fixedPricePost.BuyerId, Is.EqualTo(guidOfBuyer));
        }
    }
}
