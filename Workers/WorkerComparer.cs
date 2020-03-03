using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workers
{
    class WorkerComparer : IComparer<BaseWorker>
    {
        public int Compare(BaseWorker x, BaseWorker y)
        {
            if (x.WhatSalary() > y.WhatSalary())
                return 1;
            else if (x.WhatSalary() < y.WhatSalary())
                return -1;
            else
                return 0;
        }
    }
}
