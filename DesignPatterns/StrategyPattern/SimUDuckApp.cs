namespace DesignPatterns.StrategyPattern
{
    public class SimUDuckApp
    {
        public void ExecuteSimUDuck()
        {
            var mallardDuck = new MallardDuck();
            mallardDuck.PerformQuack();
            mallardDuck.PerformFly();

            // we can set the behaviour as below
            mallardDuck.SetQuackBehaviour(new Squeak());
            mallardDuck.SetFlyBehaviour(new FlyNoWay());
            mallardDuck.PerformQuack();
            mallardDuck.PerformFly();

            var woddenDuck = new WoddenDuck();
            woddenDuck.SetFlyBehaviour(new FlyNoWay());
            woddenDuck.SetQuackBehaviour(new MuteQuack());
            woddenDuck.PerformQuack();
            woddenDuck.PerformFly();
        }
    }
}
