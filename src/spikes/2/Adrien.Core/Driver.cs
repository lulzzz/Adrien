using System;

using Serilog;

namespace Adrien
{
    public class Driver
    {
        #region Properties
        public static LoggerConfiguration LoggerConfiguration { get; protected set; }
        public static bool LoggerConfigured { get; protected set; }
        #endregion
        public static void CreateDefaultLogger()
        {
            LoggerConfiguration = new LoggerConfiguration()
                .WriteTo.RollingFile("Adrien.log", 
                outputTemplate: "{Timestamp:HH:mm:ss}[{ThreadId:d2}] [{Level:u3}] {Message}{NewLine}{Exception}");
            Log.Logger = LoggerConfiguration.CreateLogger();
            LoggerConfigured = true;
        }
    }
}
