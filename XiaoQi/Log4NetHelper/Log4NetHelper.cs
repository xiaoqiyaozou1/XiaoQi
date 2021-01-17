using log4net;
using log4net.Config;
using log4net.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace XiaoQi
{
    public class Log4NetHelper
    {

        private static ILoggerRepository repository { get; set; }
        private static ILog _log;
        private static ILog log
        {
            get
            {
                if (_log == null)
                {
                    Configure();
                }
                return _log;
            }
        }

        public static void Configure(string repositoryName = "NETCoreRepository", string configFile = "Log4net.config")
        {
            repository = LogManager.CreateRepository(repositoryName);
            XmlConfigurator.Configure(repository, new FileInfo(configFile));
            _log = LogManager.GetLogger(repositoryName, "");
        }

        public static void Info(string msg, Exception e)
        {
            log.Info(msg, e);
        }

        public static void Warn(string msg, Exception e)
        {
            log.Warn(msg, e);
        }

        public static void Error(string msg, Exception e)
        {
            log.Error(msg, e);
        }
    }
}
