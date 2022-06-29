using MessageLogger.Loggers;
using MessageLogger;

namespace UsageExample
{
    class Program
    {
        static void Main(string[] args)
        {
            //Работа с консольным логгером
            ILogger consoleLogger = new ConsoleLogger();

            consoleLogger.Log( LogLevel.Warn, "WarningConsoleLog", new ApplicationException() );
            consoleLogger.Log(LogLevel.Info, "InfoConsoleLog");

            //Работа с файловым логгером
            ILogger fileLogger = new FileLogger();

            fileLogger.Log( LogLevel.Error, "Error accured1", new Exception());
            fileLogger.Log(LogLevel.Debug, "Error accured2");

            //Работа с логгером записывающим в базу данных
            string connectionString = @"Data Source=DESKTOP-GN1747D\SQLEXPRESS;Initial Catalog=LogDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            ILogger dbLogger = new DbLogger(connectionString);

            dbLogger.Log(LogLevel.Error, "logForDb");
            dbLogger.Log(LogLevel.Debug, "logForDbDebug", new Exception());
            for (int i = 0; i < 400; i++)
            {
                dbLogger.Log(LogLevel.Debug, "logForDbDebug" + i, new Exception());
            }
        }
    }
}