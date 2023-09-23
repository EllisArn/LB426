namespace ArnLehnerLB_426
{
    public class JetonArea : IObserver, IConsoleArea
    {
        private readonly ISubject _player = Player.Instance;
        private readonly int _x;
        private readonly int _y;
        protected IConsoleWrapper Console { get; set; }
        public JetonArea(int x, int y, IConsoleWrapper? console = null)
        {
            Console = console ?? new ConsoleWrapperImpl();
            _x = x;
            _y = y;
        }

        public void RefreshArea(string text)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            int consoleWidth = Console.WindowWidth;
            int textLength = text.Length;
            int spacing = consoleWidth / 2 - textLength / 2;
            string line = new string('-', consoleWidth);
            Console.SetCursorPosition(_x, _y);
            Console.Write(new string(' ', consoleWidth));
            Console.SetCursorPosition(spacing, Console.CursorTop);
            Console.WriteLine(text);
            Console.WriteLine(line);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void ClearArea()
        {
            // not needed
        }

        public void Update()
        {
            RefreshArea($"Jetons: {_player.Jetons}");
        }
    }
}
