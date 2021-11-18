using Framework.Service.Interfaces;
using Framework.Service.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Framework.ConsoleApp
{
    class Program
    {
        static IServiceProvider ServiceProvider;

        static void Main(string[] args)
        {
            SetupServices();

            var running = true;

            while (running)
            {
                Console.WriteLine("Input a number to decompose (Type Q to Quit):");
                var numberString = Console.ReadLine();

                if (numberString.Equals("Q", StringComparison.OrdinalIgnoreCase))
                {
                    running = false;
                    Console.WriteLine("End");
                    continue;
                }

                int number;

                if (int.TryParse(numberString, out number))
                {
                    try
                    {
                        var service = ServiceProvider.GetService<IMathService>();
                        var resultTask = service.DecomposeValueAsync(number);
                        resultTask.Wait();
                        var result = resultTask.Result;

                        Console.WriteLine($"- IsPrime: {result.IsPrime}");
                        Console.WriteLine($"- Dividers: {string.Join(", ", result.Dividers)}");
                        Console.WriteLine($"- Prime Numbers: {string.Join(", ", result.PrimeNumbers)}");
                    }
                    catch (AggregateException ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid number!");
                }

                Console.WriteLine("-----");
            }
        }

        static void SetupServices()
        {
            ServiceProvider = new ServiceCollection()
                .AddTransient<IMathService, MathService>()
                .BuildServiceProvider();
        }
    }
}
