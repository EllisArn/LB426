namespace ArnLehnerLB_426
{
    public class JetonChange : IState
    {
        private readonly ISubject _player = Player.Instance;
        private readonly IConsoleArea _textArea = TextArea.Instance;
        private int _selected = 1;
        protected IConsoleWrapper Console { get; set; }

        public JetonChange(IConsoleWrapper? console = null)
        {
            Console = console ?? new ConsoleWrapperImpl();
            PrintQuestionAndAmount();
        }

        public void PressArrowUp(Menu menu)
        {
            _selected = _selected == 1 ? 5 : _selected - 1;
            PrintQuestionAndAmount();
        }

        public void PressArrowDown(Menu menu)
        {
            _selected = _selected == 5 ? 1 : _selected + 1;
            PrintQuestionAndAmount();
        }

        public void PressEnter(Menu menu)
        {
            int jetons = _selected * 100;
            _player.AddJetons(jetons);
            menu.State = new GameChooser();
        }

        private void PrintQuestionAndAmount()
        {
            _textArea.ClearArea();
            _textArea.RefreshArea("How many jetons do you want?");
            string options = "";
            for (int i = 1; i <= 5; i++)
            {
                options += i == _selected ? $"\r\n>{i * 100}" : $"\r\n {i * 100}";
            }
            _textArea.RefreshArea(options);
        }
    }
}