using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.TwTwFFTAdapterService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            try
            {
                /*
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[] 
                { 
                    new TwTwReceiverService() 
                };
                ServiceBase.Run(ServicesToRun);
                 * */

                var service = new TwTwFFTAdapterService();
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
            catch (Exception)
            {

            }
        }
    }
}
