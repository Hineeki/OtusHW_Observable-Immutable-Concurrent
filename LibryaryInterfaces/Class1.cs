namespace LibryaryInterfaces
{
    public interface IObserver
    {
        void Update(string eventDetails);
    }

    public interface ISubject
    {
        void RegisterObserver(IObserver observer);
        void RemoveObserver(IObserver observer);
        void NotifyObservers(string eventMessage);
    }
}