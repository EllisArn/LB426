namespace ArnLehnerLB_426
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.White;

            ISubject player = new Player(0);
            IObserver jetonArea = new JetonArea(0, 0);
            IObserver security = new Security();

            player.Attach(jetonArea);
            player.Attach(security);

            IConsoleArea textArea = new TextArea(0, 3);

            Menu menu = new Menu();

            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                HandleKeyPress(keyInfo, menu);
            }
        }

        private static void HandleKeyPress(ConsoleKeyInfo keyInfo, Menu menu)
        {
            switch (keyInfo.Key)
            {
                case ConsoleKey.Enter:
                    menu.PressEnter();
                    break;
                case ConsoleKey.UpArrow:
                    menu.PressArrowUp();
                    break;
                case ConsoleKey.DownArrow:
                    menu.PressArrowDown();
                    break;
            }
        }
    }
}