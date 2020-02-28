using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole.Loggers
{
    public class TraceLogger : DebugLogger, IDisposable
    {
        public void Dispose()
        {
            Trace.Flush();
        }

        public override void Log(string Message, string Category)
        {
            System.Diagnostics.Trace.WriteLine($">>>>>> {Message}", Category);
        }

        public override void Log(string Message)
        {
            System.Diagnostics.Trace.WriteLine($">>>>>> {Message}");
        }
    }
}
