using System;
using System.Threading.Tasks;
using DesignPatterns;

namespace Programs
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            // new AllPrograms().CallPrograms();
            await new AllPatterns().CallAllPatterns();
        }
    }
}
