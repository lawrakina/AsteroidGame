﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartamentManager.Models
{
    class Departamen
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Employee> Employees { get; set; }
        public override string ToString()
        {
            return $"Id:{Id}, Name:{Name}, Employees Count:{Employees.Count}";
        }
    }
}
