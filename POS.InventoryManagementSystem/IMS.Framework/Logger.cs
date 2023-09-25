using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Framework
{
    using log4net;
    using log4net.Appender;
    using log4net.Layout;
    using log4net.Repository.Hierarchy;

    public static class Logger
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Logger));

        static Logger()
        {
            Hierarchy hierarchy = (Hierarchy)LogManager.GetRepository();
            hierarchy.Root.RemoveAllAppenders();

            RollingFileAppender roller = new RollingFileAppender
            {
                Layout = new PatternLayout("%date [%thread] %-5level %logger - %message%newline"),
                File = "log-file.log",
                AppendToFile = true,
                RollingStyle = RollingFileAppender.RollingMode.Size,
                MaxSizeRollBackups = 10,
                MaximumFileSize = "10MB",
                StaticLogFileName = true
            };
            roller.ActivateOptions();

            hierarchy.Root.AddAppender(roller);
            hierarchy.Root.Level = log4net.Core.Level.All;

            hierarchy.Configured = true;
        }

        public static void Info(string message)
        {
            log.Info(message);
        }

        public static void Error(Exception ex)
        {
            log.Error(ex.Message + " \n " + ex.StackTrace+ " \n ");
        }

        // Add more log levels and methods as needed...
    }

}
