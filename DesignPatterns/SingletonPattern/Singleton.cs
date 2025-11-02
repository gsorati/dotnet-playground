using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.SingletonPattern
{
    public class Singleton
    {
        public Singleton() { }
        public async Task ExecuteSingletonAsync()
        {
            SingletonTreditional instance1 = SingletonTreditional.GetSingleton();
            SingletonTreditional instance2 = SingletonTreditional.GetSingleton();
            Console.WriteLine($"Are both instances equal? {instance1 == instance2}");
            SingletonEgar instanceEgar1 = SingletonEgar.Instance;
            SingletonEgar instanceEgar2 = SingletonEgar.Instance;
            Console.WriteLine($"Are both Egar instances equal? {instanceEgar1 == instanceEgar2}");
            SingletonLazy instanceLazy1 = SingletonLazy.Singelton;
            SingletonLazy instanceLazy2 = SingletonLazy.Singelton;
            Console.WriteLine($"Are both Lazy instances equal? {instanceLazy1 == instanceLazy2}");
            SingletonWithLock instanceLock1 = SingletonWithLock.GetSingeTon();
            SingletonWithLock instanceLock2 = SingletonWithLock.GetSingeTon();
            Console.WriteLine($"Are both Lock instances equal? {instanceLock1 == instanceLock2}");
            await Task.CompletedTask;
        }
    }

    // Traditional Singleton Implementation, which creates the instance when it is requested for the first time. This is not thread-safe.
    public sealed class SingletonTreditional
    {
        private static SingletonTreditional? instance;

        private SingletonTreditional()
        {
        }

        public static SingletonTreditional GetSingleton()
        {
            if (instance == null)
                instance = new SingletonTreditional();

            return instance;
        }
    }

    // To make it thread-safe, you can use below mechanisms as shown below:
    // Eager Initialization Singleton Implementation, which creates the instance at the time of class loading. This is thread-safe.
    // lazy Initialization Singleton Implementation using Lazy<T>, which is also thread-safe.
    // Singleton Implementation with Lock, which uses a lock to ensure that only one thread can create the instance at a time. However, this approach can lead to performance issues due to the overhead of acquiring and releasing the lock.

    // sealed keyword is used to prevent inheritance, which could potentially lead to multiple instances of the singleton class. Ideally this is not required for Singleton pattern. but to be more safe and better readability we can use it.
    public sealed class SingletonEgar
    {
        private static readonly SingletonEgar instance = new SingletonEgar();

        private SingletonEgar()
        {
        }

        public static SingletonEgar Instance
        {
            get
            {
                return instance;
            }
        }
    }

    public sealed class SingletonLazy
    {
        private static readonly Lazy<SingletonLazy> singletonLazy = new Lazy<SingletonLazy>(() => new SingletonLazy());

        public static SingletonLazy Singelton
        {
            get { return singletonLazy.Value; }
        }

        private SingletonLazy()
        {
        }
    }

    public sealed class SingletonWithLock
    {
        private static SingletonWithLock? instance;
        private static readonly object _lock = new object();

        private SingletonWithLock()
        {
        }

        public static SingletonWithLock GetSingeTon()
        {
            lock (_lock)
            {
                if (instance == null)
                    instance = new SingletonWithLock();

                return instance;
            }
        }
    }
}
