using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using MessageLogger.MessageFormats;

namespace MessageLogger.Loggers
{
    //Запись логов в файл
    public class FileLogger : ILogger
    {
        public string FilePath = @"..\LogFile.txt"; //Путь по умолчанию
        public string CurrentTime 
        {
            get => DateTime.Now.ToLongTimeString();
        }

        //Опциональные конструкторы
        public FileLogger(string filePath)
        {
            FilePath = filePath;
        }
        public FileLogger() { }

        //Логика записи лога
        //Если файл не создан, то он создается и добавляется лог, иначе добавляется лог
        public void Log(LogLevel level, string message, Exception exception = null)
        {
            if (!File.Exists(FilePath))
            {
                using (StreamWriter writer = File.CreateText(FilePath))
                {
                    var response = StandardMessage.CastMessage(message, level, exception, CurrentTime);
                    writer.WriteLine(response);
                }
            }
            else
            {
                using (StreamWriter writer = new StreamWriter(FilePath, true))
                {
                    var response = StandardMessage.CastMessage(message, level, exception, CurrentTime);
                    writer.WriteLine(response);
                }
            }
        }
    }
}
