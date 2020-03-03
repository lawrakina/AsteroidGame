using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workers
{
    public static class Workers
    {
        private static BaseWorker[] _Workers;
        public static BaseWorker[] ArrayWorkers { get { return _Workers; } set { _Workers = value; } }
        public static List<BaseWorker> GetList() => _Workers.ToList();

        //в статическом классе нельзя использовать перегрузку ToString, почему не знаю, использовал new -> работает)))
        public static new string ToString()
        {
            string result = "";
            foreach (BaseWorker w in ArrayWorkers)
            {
                result += $"{w.ToString()}\r\n ";
            }
            return result;
        }
    }
}
