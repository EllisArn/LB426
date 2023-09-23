namespace ArnLehnerLB_426
{
    public class TextArea : IConsoleArea
    {
        private static IConsoleArea _instance = null!;
        private readonly int _x;
        private readonly int _y;
        private int _lines;
        protected IConsoleWrapper Console { get; set; }
        public TextArea(int x, int y, IConsoleWrapper? console = null)
        {
            Console = console ?? new ConsoleWrapperImpl();
            _x = x;
            _y = y;
            _instance = this;
        }
        public static IConsoleArea Instance => _instance;

        public void RefreshArea(string text)
        {
            int consoleWidth = Console.WindowWidth;
            string[] lines = text.Split("\r\n");
            for (int i = 0; i < lines.Length; i++)
            {
                Console.SetCursorPosition(_x, _y + _lines + i);
                Console.SetCursorPosition((consoleWidth - lines[i].Length) / 2, Console.CursorTop);
                Console.WriteLine(lines[i]);
                if (i == lines.Length - 1)
                {
                    _lines += lines.Length;
                }
            }
        }
        public void ClearArea()
        {
            int consoleWidth = Console.WindowWidth;
            Console.SetCursorPosition(_x, _y);

            for (int i = 0; i < _lines; i++)
            {
                Console.SetCursorPosition(_x, _y + i);
                Console.Write(new string(' ', consoleWidth));
            }
            Console.SetCursorPosition(_x, _y);
            _lines = 0;
        }
    }

}