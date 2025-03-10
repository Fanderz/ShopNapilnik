namespace Store
{
    public struct Shop
    {
        private Warehouse _warehouse;
        private Cart _cart;

        public Shop(Warehouse warehouse)
        {
            _warehouse = warehouse;
            _cart = new Cart(_warehouse);
        }

        public Cart Cart() =>
            _cart == null ? _cart : new Cart(_warehouse);
    }
}
