using System.Collections.ObjectModel;

namespace LibraryObservableCollection
{
    public class Shop
    {
        private ObservableCollection<Customer> _customers;
        private List<Item> _items;
        public event Action<string> ItemChanged;
        public Shop() 
        {
            _items = new List<Item>() { new Item(), new Item() };
            _customers = new ObservableCollection<Customer>();
        }
        public void DisplayItems()
        {
            foreach (var item in _items)
            {
                Console.WriteLine($"{item.Name} id {item.Id}");
            }
        }
        public void AddItem(Item item)
        {
            if(item == null) throw new ArgumentNullException("have no item");
            _items.Add(item);
            NotifyObservers($"Добавлен {item.Name}. ID {item.Id}");
        }
        public void RemoveItem(int itemID)
        {
            foreach (var item in _items)
            {
                if(item.Id == itemID)
                {
                    var itemToRemove = _items.Find(x => x.Id == itemID);//берём "типичный" элемент коллекции=> вызываем какой-нибудь параметр "типичного" элемента и сраниваем со входящим значением. WOW
                    _items.Remove(itemToRemove);
                    NotifyObservers($"Удалён {itemToRemove.Name}. ID {itemToRemove.Id}");
                    break;
                }
                else
                {
                    Console.WriteLine("Тoвар не был найден.");
                    return;
                }
            }
        }
        public void RegisterCustomer(Customer customer)
        {
            _customers.Add(customer);
        }
        public void UnregisterCustomer(Customer customer)
        {
            _customers.Remove(customer);
        }
        public void NotifyObservers(string eventMessage)
        {
            foreach (var customer in _customers)
            {
                customer.OnItemChanged(eventMessage);
            }
        }
    }
    public class Item
    {
        private int _id;
        private string _name;
        Random _random = new Random();
        public Item()
        {
            _name = $"Товар от {DateTime.Now}";
            _id = _random.Next(1000,4321);
        }

        public string Name { get { return _name; } }
        public int Id { get { return _id; } }
    }
}