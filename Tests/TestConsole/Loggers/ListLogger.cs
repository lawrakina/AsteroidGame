using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole.Loggers
{
    public class ListLogger : Logger
    {
        private readonly List<string> _Messages = new List<string>();
        public string[] Messages => _Messages.ToArray();
        public override void Log(string Message)
        {
            _Messages.Add($"({DateTime.Now}){Message}");
        }

    }
}
