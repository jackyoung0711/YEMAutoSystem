using System;
using System.Text;
using NLog;
using NLog.Config;
using NLog.Layouts;
using NLog.Targets;

namespace JYM.Lib
{
    public class JYMNLogger
    {
        /// <summary>
        ///     The application logger
        /// </summary>
        private static readonly Lazy<ILogger> ApplicationLogger = new Lazy<ILogger>(() => InitApplicationLogger());

        /// <summary>
        ///     Initializes the <see cref="NLogger" /> class.
        /// </summary>
        static JYMNLogger()
        {
            LoggingConfiguration config = new LoggingConfiguration();

            FileTarget target = new FileTarget
            {
                AutoFlush = true,
                CreateDirs = true,
                Encoding = Encoding.UTF8,
                FileName = Layout.FromString(AppDomain.CurrentDomain.BaseDirectory + "Logs\\${shortdate}.log"),
                Layout = Layout.FromString("${date} [${level:format=FirstCharacter}] ${message} ${onexception:${exception:format=tostring}"),
                ArchiveAboveSize = 10240,
                ArchiveNumbering = ArchiveNumberingMode.Sequence,
                ArchiveFileName = "Logs\\${basedir}/archives/${shortdate}.{#####}.log"
            };
            config.AddTarget("ApplicationTarget", target);
            config.LoggingRules.Add(new LoggingRule("ApplicationLogger", LogLevel.Info, target));
            LogManager.Configuration = config;
        }

        /// <summary>
        ///     Gets the logger.
        /// </summary>
        /// <value>The logger.</value>
        public static ILogger Logger => ApplicationLogger.Value;

        /// <summary>
        ///     Initializes the application logger.
        /// </summary>
        /// <returns>NLog.ILogger.</returns>
        private static ILogger InitApplicationLogger()
        {
            return LogManager.GetLogger("ApplicationLogger");
        }
    }
}