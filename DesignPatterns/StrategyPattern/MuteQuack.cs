using DesignPatterns.StrategyPattern.Interface;

namespace DesignPatterns.StrategyPattern
{
    public class MuteQuack : IQuackBehaviour
    {
        #region Methods

        public void Quack()
        {
            Console.WriteLine("I am not quacking!!!");
        }

        #endregion
    }
}
