using System;

namespace Store
{
    class Program
    {
        static void Main(string[] args)
        {
            Good iPhone12 = new Good("IPhone 12");
            Good iPhone11 = new Good("IPhone 11");

            Warehouse warehouse = new Warehouse();

            Shop shop = new Shop(warehouse);

            warehouse.Delive(iPhone12, 10);
            warehouse.Delive(iPhone11, 1);

            //Вывод всех товаров на складе с их остатком
            warehouse.Show("На складе:");

            Console.WriteLine("Для продолжения нажмите любую клавишу...\r\n");
            Console.ReadKey();

            Cart cart = shop.Cart();
            cart.Add(iPhone12, 10);
            cart.Add(iPhone11, 1);
            //cart.Add(iPhone11, 3); //при такой ситуации возникает ошибка так, как нет нужного количества товара на складе

            //Вывод всех товаров в корзине
            cart.Show("В корзине:");

            Console.WriteLine("Для продолжения нажмите любую клавишу...\r\n");
            Console.ReadKey();

            Console.WriteLine(cart.Order().Paylink);

            Console.WriteLine("Для продолжения нажмите любую клавишу...\r\n");
            Console.ReadKey();

            warehouse.Show("На складе осталось:"); // Результаты для тестирования
            Console.WriteLine("Для продолжения нажмите любую клавишу...\r\n");
            Console.ReadKey();

            //cart.Add(iPhone12, 9); //Ошибка, после заказа со склада убираются заказанные товары
        }
    }
}
