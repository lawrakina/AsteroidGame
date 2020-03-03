using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workers
{
    class FixedPayWorker : BaseWorker
    {

        public FixedPayWorker(string _Name, double _Salary)
        {
            this._Name = _Name;
            this._Salary = _Salary;
        }

        public override string GetName()
        {
            return _Name;
        }

        public override double WhatSalary()
        {
            return _Salary;
        }

        public override string ToString()
        {
            return $"Name: {GetName()}, Зарплата: {WhatSalary()}руб\\мес, Работник с фиксированной зарплатой";
        }
    }
}
