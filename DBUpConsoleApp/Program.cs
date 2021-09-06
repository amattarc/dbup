using DbUp;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace DBUpConsoleApp
{
    class Program
    {
        public static int Main(string[] args)
        {
            var connectionString =
                args.FirstOrDefault()
                ?? "Server=(localdb)\\MSSQLLocalDB; Database=MyApp; Trusted_connection=true";

            //var config = new ConfigurationBuilder()
            //    //.SetBasePath()
            //    .AddJson


            var upgrader =
                DeployChanges.To
                    .SqlDatabase(connectionString)
                    .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                    .LogToConsole()
                    .Build();

            EnsureDatabase.For.SqlDatabase(connectionString);

            var result = upgrader.PerformUpgrade();

            if (!result.Successful)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(result.Error);
                Console.ResetColor();
#if DEBUG
                Console.ReadLine();
#endif
                return -1;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Success!");
            Console.ResetColor();
            return 0;
        }
    }
}
