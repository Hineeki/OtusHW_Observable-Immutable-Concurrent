namespace LibraryObservableCollection
{
    public class Customer
    {
        public void OnItemChanged(string message)
        {
            Console.WriteLine($"Изменение в магазине: {message}");
        }
    }
}
