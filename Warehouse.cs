using System;

namespace Store
{
    public class Warehouse : BaseProducts
    {
        public void Delive(Good product, int count) =>
            Add(product, count);

        public void OnProductOrder(Good product, int count) =>
            Remove(product, count);
    }
}
