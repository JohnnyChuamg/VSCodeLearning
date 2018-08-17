using System;
using System.Threading;

namespace IoT.WebJob.DataRecevier
{
    class Program
    {
        static CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
