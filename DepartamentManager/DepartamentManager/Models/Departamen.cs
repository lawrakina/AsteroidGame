using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartamentManager.Models
{
    class Departamen : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string Name { get; set; }
        private List<Employee> _Employees;
        public List<Employee> Employees { get => _Employees; set {
                _Employees = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
            } }

        public event PropertyChangedEventHandler PropertyChanged;

        public override string ToString()
        {
            return $"Id:{Id}, Name:{Name}, Employees Count:{Employees.Count}";
        }
    }
}
