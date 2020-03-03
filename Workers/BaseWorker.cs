using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workers
{
    public abstract class BaseWorker //: IComparable
    {
        public string _Name;
        public double _Salary;

        //перенос сортировки в WorkerComparer
        /*public int CompareTo(object obj)
        {
            BaseWorker o = obj as BaseWorker;
            return this.WhatSalary.CompareTo( o.WhatSalary);
            //return this.WhatSalary() > ((BaseWorker)obj).WhatSalary() ? 0 : 1;
        }*/

        public abstract string GetName();
        public abstract double WhatSalary();
    }
}
