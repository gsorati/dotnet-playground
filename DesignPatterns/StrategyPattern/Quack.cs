using DesignPatterns.StrategyPattern.Interface;

namespace DesignPatterns.StrategyPattern
{
    public class Quack : IQuackBehaviour
    {
        void IQuackBehaviour.Quack()
        {
            Console.WriteLine("I am Quacking!!!");
        }
    }
}
