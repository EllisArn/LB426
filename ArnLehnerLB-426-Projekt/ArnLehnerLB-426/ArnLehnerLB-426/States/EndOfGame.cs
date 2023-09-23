namespace ArnLehnerLB_426
{
    public class EndOfGame : IState
    {
        private readonly IConsoleArea _textArea = TextArea.Instance;
        private int _selected = 1;
        protected IConsoleWrapper Console { get; set; }
        public EndOfGame(IConsoleWrapper? console = null!)
        {
            Console = console ?? new ConsoleWrapperImpl();
            PrintQuestionAndPossibilities();
        }
        public void PressArrowUp(Menu menu)
        {
            _selected = (_selected == 1) ? 2 : _selected - 1;
            PrintQuestionAndPossibilities();
        }
        public void PressArrowDown(Menu menu)
        {
            _selected = (_selected == 2) ? 1 : _selected + 1;
            PrintQuestionAndPossibilities();
        }
        public void PressEnter(Menu menu)
        { 
            if (_selected == 1) menu.State = new GameChooser(); 
            else CloseTheCasino();
        }
        private void PrintQuestionAndPossibilities()
        {
            _textArea.ClearArea();
            _textArea.RefreshArea("The game has ended, do you want to play a different game or close the casino?");
            _textArea.RefreshArea(_selected == 1 ? "\r\n>Different game\r\n Close the casino" : "\r\n Different game\r\n>Close the casino");
        }
        private void CloseTheCasino()
        {
            _textArea.ClearArea();
            _textArea.RefreshArea("Dear player, thank you very much for visiting our casino, hope we see you soon!");
            _textArea.RefreshArea(" \r\n[Press any key to close the casino]");
            Console.ReadKey(false);
            Console.Exit(0);
        }
    }
}
