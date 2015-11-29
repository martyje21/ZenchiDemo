using Zenchi.Domain.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenchi.Domain;
using NLog;

namespace Zenchi.Services.Core
{
    public class NLogLoggingService : ILoggingService
    {
        readonly NLog.Logger logger;

        public NLogLoggingService()
        {
            logger = NLog.LogManager.GetCurrentClassLogger();
        }
        public string Log(Zenchi.Domain.LogLevel level, string message)
        {
            string id = Guid.NewGuid().ToString();
            logger.Log(GetLevel(level), string.Format("{0} - {1}",id, message));
            return id;
        }

        public string Log(Zenchi.Domain.LogLevel level, string format, params object[] args)
        {
            string id = Guid.NewGuid().ToString();
            logger.Log(GetLevel(level), string.Format("{0} - {1}", id, string.Format(format, args)));
            return id;
        }

        public string Log(Zenchi.Domain.LogLevel level, string format, params string[] args)
        {
            string id = Guid.NewGuid().ToString();
            logger.Log(GetLevel(level), string.Format("{0} - {1}", id, string.Format(format, args)));
            return id;
        }

        public string LogException(Exception ex, string additionalInformation)
        {
            string id = Guid.NewGuid().ToString();
            logger.Log(NLog.LogLevel.Error, ex, string.Format("{0} - {1}", id, additionalInformation));
            return id;
        }

        public string LogException(Exception ex, string format, params string[] args)
        {
            string id = Guid.NewGuid().ToString();
            logger.Log(NLog.LogLevel.Error, ex, string.Format("{0} - {1}", id, string.Format(format, args)));
            return id;
        }

        public string LogException(Exception ex, string format, params object[] args)
        {
            string id = Guid.NewGuid().ToString();
            logger.Log(NLog.LogLevel.Error, ex, string.Format("{0} - {1}", id, string.Format(format, args)));
            return id;
        }


        private NLog.LogLevel GetLevel(Zenchi.Domain.LogLevel level)
        {
            switch (level)
            {
                case Zenchi.Domain.LogLevel.Debug:
                    return NLog.LogLevel.Debug;
                case Zenchi.Domain.LogLevel.Error:
                    return NLog.LogLevel.Error;
                case Zenchi.Domain.LogLevel.Info:
                    return NLog.LogLevel.Info;
                case Zenchi.Domain.LogLevel.Verbose:
                    return NLog.LogLevel.Info;
                case Zenchi.Domain.LogLevel.Warning:
                    return NLog.LogLevel.Warn;
                default:
                    return NLog.LogLevel.Debug;
            }
        }
    }
}
