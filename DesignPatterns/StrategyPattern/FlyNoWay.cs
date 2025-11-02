using DesignPatterns.StrategyPattern.Interface;

namespace DesignPatterns.StrategyPattern
{
    public class FlyNoWay : IFlyBehaviour
    {

        #region Methods

        public void Fly()
        {
            Console.WriteLine("I am not Flying!!!");
        }

        #endregion
    }
}
