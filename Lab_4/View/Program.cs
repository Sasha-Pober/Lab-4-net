using System;
using Microsoft.Extensions.DependencyInjection;

namespace View
{
    class Program
    {
        private static IServiceProvider Config()
        {
            var collection = new ServiceCollection();

            collection.AddTransient<IProgramRunner, ProgramRunner>();

            return collection.BuildServiceProvider();
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Config().GetService<IProgramRunner>().Run();
        }
    }
}
