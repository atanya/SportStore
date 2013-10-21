using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.DAL;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class CartTests
    {
        [Test]
        public void CartStartsEmpty()
        {
            var cart = new Cart();
            Assert.AreEqual(0, cart.Lines.Count);
            Assert.AreEqual(0, cart.ComputeTotalValue());
        }

        [Test]
        public void CanAddItemsToCart()
        {
            var p1 = new Product {Id = 1};
            var p2 = new Product {Id = 2};

            var cart = new Cart();
            cart.AddItem(p1, 1);
            cart.AddItem(p1, 2);
            cart.AddItem(p2, 10);

            Assert.AreEqual(2, cart.Lines.Count, "Wrong number of lines in cart");

            var p1Line = cart.Lines.First(l => l.Product.Id == p1.Id);
            var p2Line = cart.Lines.First(l => l.Product.Id == p2.Id);

            Assert.AreEqual(3, p1Line.Quantity);
            Assert.AreEqual(10, p2Line.Quantity);
        }
    }
}
