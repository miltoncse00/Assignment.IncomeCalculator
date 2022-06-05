using Assignment.IncomeCalculator.Models;
using Assignment.IncomeCalculator.Repository;
using Assignment.IncomeCalculator.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace Assignment.IncomeCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            System.AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionTrapper;
            
            var services = new ServiceCollection();
            ConfigureServices(services);
            services
                .AddLogging(config => config.AddConsole())
                .Configure<LoggerFilterOptions>(options => options.MinLevel = LogLevel.Information)
                .AddSingleton<Executor, Executor>()
                .BuildServiceProvider()
                .GetService<Executor>()
                .Execute();

            Console.WriteLine("Press any key to end...");
            Console.ReadLine();
            Environment.Exit(0);
        }

        static void UnhandledExceptionTrapper(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine(e.ExceptionObject.ToString());
            Console.WriteLine("Press Enter to continue");
            Console.ReadLine();
            Environment.Exit(1);
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services
               .AddSingleton<IncomeRepository, IncomeRepository>();
            services
                .AddSingleton<IncomeCalculatorService, IncomeCalculatorService>();
            services
               .AddSingleton<UserInputsValidator, UserInputsValidator>();
            services
                .AddSingleton<ConsoleOutputWrinter, ConsoleOutputWrinter>();
            services
             .AddSingleton<ConsoleUserInputReader, ConsoleUserInputReader>();
            services
            .AddSingleton<SalaryCalculationStrategyProvider, SalaryCalculationStrategyProvider>();

        }
    }
}
