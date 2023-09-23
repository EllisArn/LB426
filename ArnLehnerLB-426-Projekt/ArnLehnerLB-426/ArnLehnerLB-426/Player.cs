namespace ArnLehnerLB_426
{
    public class Player : ISubject
    {
        private readonly List<IObserver> _observers = new List<IObserver>();
        private static ISubject _instance = null!;
        public int Jetons { get; set; }

        public Player(int jetons)
        {
            Jetons = jetons;
            _instance = this;
            Notify();
        }

        public static ISubject Instance => _instance;

        public void AddJetons(int jetons)
        {
            Jetons += jetons;
            Notify();
        }

        public void RemoveJetons(int jetons)
        {
            Jetons -= jetons;
            Notify();
        }

        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Notify()
        {
            _observers.ForEach(o => o.Update());
        }
    }
}
