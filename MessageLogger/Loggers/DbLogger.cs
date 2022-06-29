using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace MessageLogger.Loggers
{
    //Запись логов в БД, логгер получает connectionstring соединяется с БД и записывает лог
    public class DbLogger : ILogger
    {
        public string ConnectionString;
        public string CurrentTime
        {
            get => DateTime.Now.ToLongTimeString();
        }
        public DbLogger (string connectionString)
        {
            ConnectionString = connectionString;
        }

        public void Log(LogLevel level, string message, Exception exception = null)
        {
            AddToDb(level, message, exception);
        }
        //Костыльная запись лога в БД
        public void AddToDb(LogLevel level, string message, Exception exception)
        {
            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    string insertQuery = "insert into LogTable(time,logLevel,message,exception)values (@time,@logLevel,@message,@exception)";
                    SqlCommand cmd = new SqlCommand(insertQuery, connection);
                    cmd.Parameters.AddWithValue("@time", CurrentTime);
                    cmd.Parameters.AddWithValue("@logLevel", level.ToString());
                    cmd.Parameters.AddWithValue("@message", message);
                    cmd.Parameters.AddWithValue("@exception",exception == null? "NULL":exception.ToString());
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
