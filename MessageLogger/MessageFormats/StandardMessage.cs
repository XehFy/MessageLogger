using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MessageLogger.MessageFormats
{
    //Формат лога 00:00|Info|Log text|Exception(optional)
    public static class StandardMessage
    {
        public static string CastMessage(string message, LogLevel level, Exception exception, string currentTime)
        {
            return exception != null
                ? $"{currentTime}|{level.ToString()}|{message}|{exception}"
                : $"{currentTime}|{level.ToString()}|{message}";
        }
    }
}
