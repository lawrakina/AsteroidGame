using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workers
{
    class HourlyPayWorker : BaseWorker
    {
        private double _WorkingDays;
        private double _WorkingHour;

        public HourlyPayWorker(string _Name, double _HourlyPay)
        {
            _WorkingDays = 20.8;
            _WorkingHour = 8;
            this._Name = _Name;
            this._Salary = _HourlyPay;
        }

        public override string GetName()
        {
            return _Name;
        }

        public override double WhatSalary()
        {
            return _WorkingHour * _WorkingDays * _Salary;
        }
        public override string ToString()
        {
            return $"Name: {GetName()}, Зарплата: {WhatSalary()}руб\\мес, Работник с почасовой оплатой";
        }
    }
}
