using System;
using System.Collections.Generic;

namespace Store
{
    public class BaseProducts
    {
        private Dictionary<Good, int> _products = new Dictionary<Good, int>();

        public IReadOnlyDictionary<Good, int> Products { get { return _products; } }

        public virtual void Add(Good product, int count)
        {
            if (product.Name == string.Empty)
                throw new ArgumentNullException();

            if (count <= 0)
                throw new ArgumentOutOfRangeException();

            _products.Add(product, count);
        }

        public void Show(string input)
        {
            if (input == string.Empty)
                throw new ArgumentNullException();

            if (_products.Count > 0)
            {
                Console.WriteLine(input);

                foreach (KeyValuePair<Good, int> product in _products)
                    Console.WriteLine($"{product.Key.Name} в количестве: {product.Value} единиц.");
            }
            else
                throw new InvalidOperationException();
        }

        protected virtual void Remove(Good product, int count)
        {
            if (product.Name == string.Empty)
                throw new ArgumentNullException();

            if (count <= 0)
                throw new ArgumentOutOfRangeException();

            if (_products.ContainsKey(product))
            {
                int productsCount = _products[product];

                if (productsCount > count)
                    _products[product] = productsCount - count;
                else
                    _products.Remove(product);
            }
        }

        protected void Clear() =>
            _products.Clear();
    }
}
