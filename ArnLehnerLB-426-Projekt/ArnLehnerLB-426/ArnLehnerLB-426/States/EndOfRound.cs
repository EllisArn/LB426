namespace ArnLehnerLB_426
{
    public class EndOfRound : IState
    {
        private readonly IConsoleArea _textArea = TextArea.Instance;
        private readonly int _numberOfGame;
        private int _selected = 1;
        protected IConsoleWrapper Console { get; set; }
        public EndOfRound(int numberOfGame, IConsoleWrapper? console = null!)
        {
            Console = console ?? new ConsoleWrapperImpl();
            _numberOfGame = numberOfGame;
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
            menu.State = _selected == 1
                ? _numberOfGame switch
                {
                    1 => new Slotmachine(),
                    2 => new DiceGame(),
                    _ => menu.State
                }
                : new EndOfGame();
        }
        private void PrintQuestionAndPossibilities()
        {
            _textArea.ClearArea();
            _textArea.RefreshArea("The round is over, do you want to play again?");
            _textArea.RefreshArea(_selected == 1 ? "\r\n>Yes\r\n No" : "\r\n Yes\r\n>No");
        }
    }
}
