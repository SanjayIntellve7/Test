using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceProcess;

namespace AMS.Broker.WatchDogService.StreamInsight
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new StreamInsightService();


            if (!Environment.UserInteractive)
            {
                // startup as a service.
                ServiceBase.Run(new ServiceBase[] { service });
            }
            else
            {
                // startup as application
                service.StartInConsole(args);

                Console.TreatControlCAsInput = true;
                while (true)
                {
                    var keyInfo = Console.ReadKey(true);
                    if (keyInfo.Key == ConsoleKey.C && keyInfo.Modifiers == ConsoleModifiers.Control)
                    {
                        break;
                    }
                }
                service.StopInConsole();
            }
        }
    }
}
