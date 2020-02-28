using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole.Loggers
{
    interface ILogger
    {
        void Log(string Message);
        void LogInformation(string Message);

        void LogWarning(string Message);

        void LogError(string Message);
    }
}
