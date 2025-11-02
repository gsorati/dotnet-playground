using DesignPatterns.SingletonPattern;
using DesignPatterns.StrategyPattern;

namespace DesignPatterns
{
    public class AllPatterns
    {
        public async Task CallAllPatterns()
        {
            // Call Strategy Pattern
            // new SimUDuckApp().ExecuteSimUDuck();

            // Call Singleton Pattern
            await new Singleton().ExecuteSingletonAsync();
        }
    }
}