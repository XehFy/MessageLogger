using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MessageLogger.Loggers
{
    public interface ILogger
    {
        public string CurrentTime
        {
            get;
        }
        void Log(LogLevel level, string message, Exception exception = null);
    }
}
