namespace ArnLehnerLB_426
{
    public class MockConsoleWrapper : IConsoleWrapper
    {
        public int WindowWidth => 80;
        public int CursorTop => 0;
        public ConsoleColor ForegroundColor { get; set; }
        public void SetCursorPosition(int left, int top)
        {
            // Ignoriere die SetCursorPosition-Methode im Mock
        }
        public void WriteLine(string value)
        {
            // Ignoriere die WriteLine-Methode im Mock
        }
        public void Write(string value)
        {
            // Ignoriere die Write-Methode im Mock
        }
        public ConsoleKeyInfo ReadKey(bool b)
        {
            return new ConsoleKeyInfo(' ', ConsoleKey.Spacebar, false, false, false);
        }
        public bool KeyAvailable { get; }
        public void Exit(int exitCode)
        {
            // Ignoriere die Exit-Methode im Mock
        }
    }
}
