using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole.Loggers
{
    public abstract class DebugLogger : Logger
    {
        public abstract void Log(string Message, string Category);
    }
}
