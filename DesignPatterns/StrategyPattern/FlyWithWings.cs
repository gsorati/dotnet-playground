using DesignPatterns.StrategyPattern.Interface;

namespace DesignPatterns.StrategyPattern
{
    public class FlyWithWings : IFlyBehaviour
    {
        #region Methods

        public void Fly()
        {
            Console.WriteLine("I am Flying with Wings!!!");
        }

        #endregion
    }
}
