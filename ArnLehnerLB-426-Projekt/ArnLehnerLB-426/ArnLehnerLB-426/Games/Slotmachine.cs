namespace ArnLehnerLB_426
{
    public class Slotmachine : IState
    {
        private readonly ISubject _player = Player.Instance;
        private readonly IConsoleArea _textArea = TextArea.Instance;
        private readonly List<char> _slotmachineIcons = new List<char> { '$', '£', '£', '¥', '¥', '¥', '§', '§', '§', '§', 'Ø', 'Ø', 'Ø', 'Ø', 'Ø' };
        protected IConsoleWrapper Console { get; set; }

        public Slotmachine(IConsoleWrapper? console = null)
        {
            Console = console ?? new ConsoleWrapperImpl();
            WelcomeThePlayer();
        }

        public void PressArrowUp(Menu menu)
        {
            // Keine Operation
        }

        public void PressArrowDown(Menu menu)
        {
            // Keine Operation
        }

        public void PressEnter(Menu menu)
        {
            PlayGame();
            _textArea.RefreshArea(" \r\n[Press any key to continue]");
            while (Console.KeyAvailable) Console.ReadKey(false);
            Console.ReadKey(false);
            _textArea.ClearArea();
            menu.State = new EndOfRound(1);
        }

        private void PlayGame()
        {
            _player.RemoveJetons(10);
            int prize = EvaluateResults(SpinSlotmachine());
            _player.AddJetons(prize);
        }

        private void WelcomeThePlayer()
        {
            _textArea.ClearArea();
            _textArea.RefreshArea("Hello, dear casino player, you have entered the slot machine.");
            _textArea.RefreshArea("Press [Enter] to spin.");
        }

        private List<char> SpinSlotmachine()
        {
            Random rnd = new Random();
            List<char> slotmachineResult = new List<char>();

            _textArea.ClearArea();
            _textArea.RefreshArea("*The slot machine was spun*");
            Thread.Sleep(1000);

            for (int i = 1; i < 4; i++)
            {
                int index = rnd.Next(0, _slotmachineIcons.Count);
                char icon = _slotmachineIcons[index];
                slotmachineResult.Add(icon);
                _textArea.RefreshArea($"Icon Nr. {i} is: {icon}");
                Thread.Sleep(1000);
            }
            return slotmachineResult;
        }

        public int EvaluateResults(List<char> receivedIcons)
        {
            int prize = 0;
            if (receivedIcons.Distinct().Count() == 1)
            {
                char icon = receivedIcons[0];

                switch (icon)
                {
                    case '$':
                        prize = 150;
                        break;
                    case '£':
                        prize = 75;
                        break;
                    case '¥':
                        prize = 50;
                        break;
                    case '§':
                        prize = 35;
                        break;
                    case 'Ø':
                        prize = 20;
                        break;
                }
                Console.ForegroundColor = ConsoleColor.Green;
                _textArea.RefreshArea($"Congratulations, you have won {prize} Jetons!");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                _textArea.RefreshArea("Unfortunately, you haven't won, good luck next round!");
                Console.ForegroundColor = ConsoleColor.White;
            }
            return prize;
        }
    }
}
