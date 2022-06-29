using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessageLogger.MessageFormats;

namespace MessageLogger.Loggers
{
    public class ConsoleLogger : ILogger
    {
        public string CurrentTime
        {
            get => DateTime.Now.ToLongTimeString();
        }

        //Вывод лога в консоль
        public void Log(LogLevel level, string message, Exception exception = null)
        {
            var response = StandardMessage.CastMessage(message, level, exception, CurrentTime);
            Console.WriteLine(response);
        }
    }
}
