using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole.Loggers
{
    public class VisualStudioOutputLogger : DebugLogger
    {
        public override void Log(string Message, string Category)
        {
            System.Diagnostics.Debug.WriteLine($">>>>>> {Message}", Category);
        }

        public override void Log(string Message)
        {
            System.Diagnostics.Debug.WriteLine($">>>>>> {Message}");
        }
    }
}
