using System;

using Serilog;

namespace Adrien
{
    public class CompilerDriver
    {
        public static LoggerConfiguration LoggerConfiguration { get; protected set; }
        public static bool LoggerConfigured { get; protected set; }
        

        public static void CreateDefaultLogger(string logFilename = "Adrien.log")
        {
            LoggerConfiguration = new LoggerConfiguration()
                
                .WriteTo.RollingFile(logFilename, 
                outputTemplate: "{Timestamp:HH:mm:ss} [{Level:u3}] {Message}{NewLine}{Exception}");
            Log.Logger = LoggerConfiguration.CreateLogger();
            LoggerConfigured = true;
        }
    }
}
