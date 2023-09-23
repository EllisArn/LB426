namespace ArnLehnerLB_426
{
    public class DiceGame : IState
    {
        private readonly ISubject _player = Player.Instance;
        private readonly IConsoleArea _textArea = TextArea.Instance;
        private int _selected = 1;
        protected IConsoleWrapper Console { get; set; }

        public DiceGame(IConsoleWrapper? console = null)
        {
            Console = console ?? new ConsoleWrapperImpl();
            WelcomeThePlayer();
            PrintQuestionAndPossibilities();
        }

        public void PressArrowUp(Menu menu)
        {
            _selected = _selected == 1 ? 6 : _selected - 1;
            PrintQuestionAndPossibilities();
        }

        public void PressArrowDown(Menu menu)
        {
            _selected = _selected == 6 ? 1 : _selected + 1;
            PrintQuestionAndPossibilities();
        }

        public void PressEnter(Menu menu)
        {
            PlayGame();
            _textArea.RefreshArea(" \r\n[Press any key to continue]");
            while (Console.KeyAvailable) Console.ReadKey(true);
            Console.ReadKey(false);
            _textArea.ClearArea();
            menu.State = new EndOfRound(2);
        }

        private void WelcomeThePlayer()
        {
            _textArea.ClearArea();
            _textArea.RefreshArea("Hello, dear casino player, you have entered the dice game.");
        }

        private void PrintQuestionAndPossibilities()
        {
            _textArea.ClearArea();
            _textArea.RefreshArea("Choose a number between 1-6, if it matches the number generated afterwards you have won.");
            for (int i = 1; i <= 6; i++)
            {
                string option = i == _selected ? ">" + i : " " + i;
                _textArea.RefreshArea(option);
            }
        }

        private void PlayGame()
        {
            _player.RemoveJetons(10);
            int randomNumber = GenerateRandomNumber();
            EvaluateResults(_selected, randomNumber);
        }

        public int EvaluateResults(int userNumber, int randomNumber)
        {
            _textArea.ClearArea();
            _textArea.RefreshArea($"Your number was: {userNumber}");
            Thread.Sleep(1000);
            _textArea.RefreshArea($"The computer's number was: {randomNumber}");

            if (randomNumber == userNumber)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                _textArea.RefreshArea("Congratulations, you have won 30 Jetons");
                Console.ForegroundColor = ConsoleColor.White;
                return 30;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                _textArea.RefreshArea("Unfortunately, you haven't won. Good luck next round!");
                Console.ForegroundColor = ConsoleColor.White;
                return 0;
            }
        }

        private int GenerateRandomNumber()
        {
            Random randomNumberGenerator = new Random();
            int randomNumber = randomNumberGenerator.Next(1, 7);
            return randomNumber;
        }
    }
}
