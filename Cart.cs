using System;
using System.Collections.Generic;

namespace Store
{
    public class Cart : BaseProducts
    {
        private Warehouse _warehouse;

        public string Paylink { get; private set; }

        public Cart(Warehouse warehouse)
        {
            if (warehouse == null)
                throw new ArgumentNullException();

            _warehouse = warehouse;
        }

        public override void Add(Good product, int count)
        {
            if (product.Name == string.Empty)
                throw new ArgumentNullException();

            if (count <= 0)
                throw new ArgumentOutOfRangeException();

            if (_warehouse.Products.TryGetValue(product, out int cnt) && cnt >= count)
                base.Add(product, count);
            else
                throw new InvalidOperationException();
        }

        public Cart Order()
        {
            if (Products.Count > 0)
            {
                foreach (KeyValuePair<Good, int> pair in Products)
                    _warehouse.OnProductOrder(pair.Key, pair.Value);

                Clear();
                Paylink = "Paylink";

                return this;
            }
            else
                throw new InvalidOperationException();
        }
    }
}
