using DesignPatterns.StrategyPattern.Interface;

namespace DesignPatterns.StrategyPattern
{
    public class Squeak : IQuackBehaviour
    {
        #region Methods

        public void Quack()
        {
            Console.WriteLine("I am Squeaking!!!");
        }

        #endregion
    }
}
