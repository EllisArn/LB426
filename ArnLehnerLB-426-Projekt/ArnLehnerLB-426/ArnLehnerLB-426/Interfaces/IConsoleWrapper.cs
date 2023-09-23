namespace ArnLehnerLB_426
{
    public interface IConsoleWrapper
    {
        public int WindowWidth { get; }
        public int CursorTop { get; }
        public ConsoleColor ForegroundColor { get; set; }
        public void SetCursorPosition(int left, int top);
        public void WriteLine(string value);
        public void Write(string value);
        public ConsoleKeyInfo ReadKey(bool b);
        public bool KeyAvailable { get; }
        public void Exit(int exitCode);
    }
}
