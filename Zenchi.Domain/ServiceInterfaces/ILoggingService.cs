using Zenchi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zenchi.Domain.ServiceInterfaces
{
    public interface ILoggingService
    {
        string Log(LogLevel level, string message);
        string Log(LogLevel level, string format, params string[] args);
        string Log(LogLevel level, string format, params object[] args);
        string LogException(Exception ex, string additionalInformation);
        string LogException(Exception ex, string format, params string[] args);
        string LogException(Exception ex, string format, params object[] args);
    }
}
