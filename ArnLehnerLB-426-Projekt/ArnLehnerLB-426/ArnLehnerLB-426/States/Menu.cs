namespace ArnLehnerLB_426
{
    public class Menu
    {
        public IState State { get; set; } = new JetonChange();
        public void PressArrowUp()
        {
            State.PressArrowUp(this);
        }
        public void PressArrowDown()
        {
            State.PressArrowDown(this);
        }
        public void PressEnter()
        {
            State.PressEnter(this);
        }
    }
}
