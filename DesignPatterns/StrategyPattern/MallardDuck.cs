namespace DesignPatterns.StrategyPattern
{
    public class MallardDuck : Duck
    {
        #region Consotructor

        public MallardDuck()
        {
            // overriding the behaviour. we can achive using below code are while creating new object can be set.
            this.QuackBehaviour = new Quack();
            this.FlyBehaviour = new FlyWithWings();
        }

        #endregion

        #region Methods

        public override void PrintDisplay()
        {
            Console.WriteLine("I am a MallardDuck!!!");
        }

        #endregion
    }
}
