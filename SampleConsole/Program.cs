using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace SampleConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadPool.GetAvailableThreads(out int availableThreads, out int port);
            Console.WriteLine(availableThreads);
            Console.WriteLine(port);
            ThreadPool.SetMinThreads(1, 1);
            ThreadPool.SetMaxThreads(2, 1);

            Console.WriteLine(ThreadPool.ThreadCount);
            Console.WriteLine(ThreadPool.PendingWorkItemCount);
            Console.WriteLine(ThreadPool.CompletedWorkItemCount);
            Console.ReadKey();

            MyAsyncMethod();

            Console.ReadKey();
        }

        public static async Task MyAsyncMethod()
        {
            await Task.Run(() => doSomething());
            Console.WriteLine("I thought this should come first");
            //await task;
        }

        public static async Task doSomething()
        {
            await Task.Delay(5000);
            Console.WriteLine("I should come second");
        }

        public static IEnumerable<double> M2(double number)
        {
            var res = new List<double>();
            for (int i = 1; i <= number; i++)
            {
                res.Add(Math.Pow(1.01, i));
            }

            return res;
        }

        public static IEnumerable<double> YM2(double number)
        {
            for (int i = 1; i <= number; i++)
            {
                yield return Math.Pow(1.01, i);
            }
        }

        //public static Task<IEnumerable<double>> M2(double number)
        //{
        //    var res = new List<double>();
        //    var task = new Task<IEnumerable<double>>(() =>
        //    {
        //        for (int i = 1; i <= number; i++)
        //        {
        //            res.Add(Math.Pow(1.01, i));
        //        }

        //        return res;
        //    });

        //    return task;
        //}

        //public static Task<IEnumerable<double>> YM2(double number)
        //{
        //    var res = new List<double>();
        //    var task = new Task<IEnumerable<double>>(() =>
        //    {
        //        for (int i = 1; i <= number; i++)
        //        {
        //            yield return Math.Pow(1.01, i);
        //        }

        //        return res;
        //    });

        //    return task;
        //}
    }
}
