using System;
using System.Collections.Generic;

namespace Store
{
    public class Cart : BaseProducts
    {
        private Shop _shop;

        public Cart(Shop shop)
        {
            if (shop == null)
                throw new ArgumentNullException();

            _shop = shop;
        }

        public string Paylink { get; private set; }

        public override void Add(Good product, int count)
        {
            if (product.Name == string.Empty)
                throw new ArgumentNullException();

            if (count <= 0)
                throw new ArgumentOutOfRangeException();

            if (_shop.HaveGood(product, count) == false)
                throw new InvalidOperationException();

            base.Add(product, count);
        }

        public Cart Order()
        {
            if (Products.Count < 0)
                throw new InvalidOperationException();

            foreach (KeyValuePair<Good, int> pair in Products)
                _shop.OrderProduct(pair.Key, pair.Value);

            Clear();
            Paylink = "Paylink";

            return this;
        }
    }
}
