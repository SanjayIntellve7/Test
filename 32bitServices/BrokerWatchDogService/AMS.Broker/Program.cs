using System;
using System.ServiceProcess;

namespace AMS.Broker.WatchDogService
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                var service = new BrokerService();

                if (!Environment.UserInteractive)
                {
                    // startup as a service.
                    ServiceBase.Run(new ServiceBase[] { service });
                }
                else
                {
                    // startup as application
                    service.StartInConsole(args);
                    try
                    {
                        Console.TreatControlCAsInput = true;
                        while (true)
                        {
                            try
                            {
                                var keyInfo = Console.ReadKey(true);
                                if (keyInfo.Key == ConsoleKey.C && keyInfo.Modifiers == ConsoleModifiers.Control)
                                {
                                    break;
                                }
                            }
                            catch (Exception e)
                            {
                                break;
                            }
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                    service.StopInConsole();
                }
            }
            catch (Exception es)
            {
            }
        }
    }
}
