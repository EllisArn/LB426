namespace ArnLehnerLB_426
{
    public class Security : IObserver
    {
        private readonly ISubject _player = Player.Instance;
        protected IConsoleWrapper Console { get; set; }
        public Security(IConsoleWrapper? console = null!)
        {
            Console = console ?? new ConsoleWrapperImpl();
        }

        public void Update()
        {
            if (_player.Jetons > 0) return;
            IConsoleArea textArea = TextArea.Instance;
            Console.ForegroundColor = ConsoleColor.Red;
            textArea.ClearArea();
            textArea.RefreshArea("Hello casino player, you don't have any more jetons.\r\nWe will have to ask you to leave. This way.\r\n\r\n[Press any key to leave]");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey(false);
            Console.Exit(0);
        }
    }
}
