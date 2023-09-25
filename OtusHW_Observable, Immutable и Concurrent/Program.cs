using LibraryObservableCollection;

namespace OtusHW_Observable__Immutable_и_Concurrent
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Shop shop = new Shop();
            Customer customer = new Customer();
            shop.RegisterCustomer(customer);
            Console.WriteLine("Для добавления товара нажмите A, для удаления - D, для выхода - X:");
            while (true)
            {
                var key = Console.ReadKey().Key;
                Console.WriteLine();

                switch (key)
                {
                    case ConsoleKey.A:
                        shop.AddItem(new Item());
                        break;

                    case ConsoleKey.D:
                        shop.DisplayItems();
                        Console.WriteLine("Введите ID товара для удаления:");
                        if (int.TryParse(Console.ReadLine(), out int itemId))
                        {
                            shop.RemoveItem(itemId);
                        }
                        else
                        {
                            Console.WriteLine("Некорректный ввод. Введите целое число для идентификатора товара.");
                        }
                        break;

                    case ConsoleKey.X:
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine("Пожалуйста, следуйте инструкциям=)\nДля добавления товара нажмите A, для удаления - D, для выхода - X:");
                        break;
                }
            }
        }
    }
}