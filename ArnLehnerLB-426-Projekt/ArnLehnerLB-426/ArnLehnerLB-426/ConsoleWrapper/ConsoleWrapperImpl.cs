namespace ArnLehnerLB_426
{
    public class ConsoleWrapperImpl : IConsoleWrapper
    {
        public int WindowWidth => Console.WindowWidth;
        public int CursorTop => Console.CursorTop;
        public ConsoleColor ForegroundColor
        {
            get => Console.ForegroundColor;
            set => Console.ForegroundColor = value;
        }
        public void SetCursorPosition(int left, int top)
        {
            Console.SetCursorPosition(left, top);
        }
        public void WriteLine(string value)
        {
            Console.WriteLine(value);
        }
        public void Write(string value)
        {
            Console.Write(value);
        }
        public ConsoleKeyInfo ReadKey(bool b)
        {
            return Console.ReadKey(b);
        }
        public bool KeyAvailable => Console.KeyAvailable;
        public void Exit(int exitCode)
        {
            Environment.Exit(exitCode);
        }
    }
}
