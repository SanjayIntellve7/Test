using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using System.Security;

namespace AMS.Broker
{
    public interface ILogger
    {
        void Log(string message);
    }

    public abstract class Logger : ILogger
    {
        public abstract void Log(string message);
        protected string CurrentTime { get { return DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString(); } }
    }

    public class ConsoleLogger : Logger
    {
        public override void Log(string message)
        {
            Console.WriteLine(CurrentTime + " : " + message);
        }
    }

    public class FileLogger : Logger
    {

        public FileLogger()
        {
            _path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }

        public override void Log(string message)
        {
            lock (_locker)
            {
                try
                {

                    _streamWriter = File.AppendText(_path + "\\" + "Broker.Log");
                    string logLine = System.String.Format("{0:G}: {1}.", System.DateTime.Now, message);
                    _streamWriter.WriteLine(logLine);
                    _streamWriter.Flush();

                }
                catch (Exception)
                {
                    // do nothing
                }
                finally
                {
                    if (_streamWriter != null) _streamWriter.Close();
                }
            }
        }

        private string _path;
        private StreamWriter _streamWriter = null;
        private object _locker = new object();

    }

    public class EventLogger : Logger
    {

        public EventLogger()
        {
            try
            {
                // SourceExists fails unless you are an admin
                if (!EventLog.SourceExists(_eventSource))
                {
                    EventLog.CreateEventSource(_eventSource, "Application");
                }

            }
            catch (SecurityException) { }

        }

        public override void Log(string message)
        {
            try
            {
                EventLog.WriteEntry(_eventSource, message, EventLogEntryType.Information, 1000);
            }
            catch (Exception e)
            {
                string s = e.Message;
            }
        }

        private const string _eventSource = "PCR Service";

    }
}
