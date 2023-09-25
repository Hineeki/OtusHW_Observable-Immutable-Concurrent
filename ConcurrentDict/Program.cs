using System.Collections.Concurrent;
using System.Timers;

namespace ConcurrentDict
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConcurrentDictionary<string, int> libryary = new ConcurrentDictionary<string, int>();
            Thread myThread = new Thread(() => Recalculation(libryary));
            myThread.IsBackground = true;
            myThread.Start();
            Console.WriteLine("1 - добавить книгу; 2 - вывести список непрочитанного; 3 - выйти");
            while (true)
            {
                ConsoleKey key = Console.ReadKey().Key;
                Console.WriteLine();
                switch (key)
                {
                    case ConsoleKey.D1:
                        Console.Write("Введите название книги:");
                        string bookName = Console.ReadLine();
                        foreach (var item in libryary)
                        {
                           if (item.Key == bookName)
                            {
                                Console.Clear();
                                Console.WriteLine("Такая книга уже есть в вашей библиотеке.\n1 - добавить книгу; 2 - вывести список непрочитанного; 3 - выйти");
                                break;
                            }
                        }
                        libryary.TryAdd(bookName, 0);
                        break;
                    case ConsoleKey.D2:
                        foreach (var item in libryary)
                        {
                            Console.WriteLine(item);
                        }
                        break;
                    case ConsoleKey.D3:
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine("Пожалуйста, следуйте инструкциям=)\n1 - добавить книгу; 2 - вывести список непрочитанного; 3 - выйти");
                        break;
                }
            }
        }
        private static void Recalculation(ConcurrentDictionary<string, int> collection)
        {
            System.Timers.Timer timer = new System.Timers.Timer(1000);
            timer.Elapsed += (sender, e) => {
                foreach (var item in collection)
                {
                    if (item.Value != 100)
                    {
                        int newValue = item.Value + 1;
                        collection.TryUpdate(item.Key, newValue, item.Value);
                    }
                    else
                    {
                        collection.TryRemove(item.Key, out int _);
                    }
                }
            };
            timer.Start();
        }
    }
}