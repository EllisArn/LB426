namespace ArnLehnerLB_426
{
    public interface ISubject
    {
        public int Jetons { get; protected set; }

        public void AddJetons(int jetons);
        public void RemoveJetons(int jetons);
        public void Attach(IObserver observer);
        protected void Notify();
    }
}
