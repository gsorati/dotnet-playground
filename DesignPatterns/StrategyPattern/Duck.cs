using DesignPatterns.StrategyPattern.Interface;

namespace DesignPatterns.StrategyPattern
{
    public abstract class Duck
    {
        #region Properties

        public IFlyBehaviour FlyBehaviour { get; set; }

        public IQuackBehaviour QuackBehaviour { get; set; }

        #endregion

        #region Methods

        public abstract void PrintDisplay();

        public void Swim()
        {
            Console.WriteLine("I am swimming!!!");
        }

        public void PerformQuack()
        {
            this.QuackBehaviour.Quack();
        }

        public void PerformFly()
        {
            this.FlyBehaviour.Fly();
        }

        public void SetFlyBehaviour(IFlyBehaviour flyBehaviour)
        {
            this.FlyBehaviour = flyBehaviour;
        }

        public void SetQuackBehaviour(IQuackBehaviour quackBehaviour)
        {
            this.QuackBehaviour = quackBehaviour;
        }

        #endregion
    }
}
