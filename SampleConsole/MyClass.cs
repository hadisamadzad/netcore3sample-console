using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SampleConsole
{
    public class MyClass
    {
        public async Task MyAsyncMethod()
        {
            await doSomething();
            Console.WriteLine("I thought this should come first");
        }

        public async Task doSomething()
        {
            await Task.Delay(5000);
            Console.WriteLine("I should come second");
        }
    }
    
}
