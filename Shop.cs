using System;

namespace Store
{
    public class Shop
    {
        private Warehouse _warehouse;
        private Cart _cart;

        public Shop(Warehouse warehouse)
        {
            _warehouse = warehouse;
        }

        public Cart Cart() =>
            _cart = new Cart(this);

        public bool HaveGood(Good good, int count)
        {
            if (good.Name == string.Empty)
                throw new ArgumentNullException();

            if (count <= 0)
                throw new ArgumentOutOfRangeException();
                
            _warehouse.Products.TryGetValue(good, out int cnt);

            if (cnt < count)
                throw new InvalidOperationException();

            return true;
        }

        public void OrderProduct(Good good, int count) =>
            _warehouse.OnProductOrder(good, count);
    }
}
