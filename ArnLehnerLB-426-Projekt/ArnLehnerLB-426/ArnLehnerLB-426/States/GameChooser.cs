namespace ArnLehnerLB_426
{
    public class GameChooser : IState
    {
        private readonly IConsoleArea _textArea = TextArea.Instance;
        private int _selected = 1;
        public GameChooser()
        {
            PrintQuestionAndGames();
        }
        public void PressArrowUp(Menu menu)
        {
            _selected = _selected == 1 ? 2 : _selected - 1;
            PrintQuestionAndGames();
        }
        public void PressArrowDown(Menu menu)
        {
            _selected = _selected == 2 ? 1 : _selected + 1;
            PrintQuestionAndGames();
        }
        public void PressEnter(Menu menu)
        {
            menu.State = _selected switch
            {
                1 => new Slotmachine(),
                2 => new DiceGame(),
                _ => menu.State
            };
        }
        private void PrintQuestionAndGames()
        {
            _textArea.ClearArea();
            _textArea.RefreshArea("What game do you want to play?");
            _textArea.RefreshArea(_selected switch
            {
                1 => "\r\n>Slotmachine\r\n Dice game",
                2 => "\r\n Slotmachine\r\n>Dice game",
                _ => ""
            });
        }
    }
}
