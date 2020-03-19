using DepartamentManager.Command;
using DepartamentManager.Data;
using DepartamentManager.Models;
using DepartamentManager.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartamentManager.ViewModels
{
    class MainWindowViewModel : ViewModel
    {
        public string Title { get; set; } = "Работа с департаментами и сотрудниками";

        private DepartamentViewModel _SelectedDepartament;
        public DepartamentViewModel SelectedDepartament
        {
            get => _SelectedDepartament;
            set => Set(ref _SelectedDepartament, value);
        }

        private EmployeeViewModel _SelectedEmployee;
        public EmployeeViewModel SelectedEmployee
        {
            get => _SelectedEmployee;
            set => Set(ref _SelectedEmployee, value);
        }

        private ObservableCollection<Departamen> _Departamens = new ObservableCollection<Departamen>();
        public ObservableCollection<Departamen> Departamens
        {
            get => _Departamens;
            set => Set(ref _Departamens, value);
        }

        private ObservableCollection<EmployeeViewModel> _Employees = new ObservableCollection<EmployeeViewModel>();
        public ObservableCollection<EmployeeViewModel> Employees
        {
            get => _Employees;
            set => Set(ref _Employees, value);
        }

        public MainWindowViewModel()
        {
            foreach (var employee in Enumerable.Range(1, 100).Select(i => new EmployeeViewModel()
            {
                Id = i,
                Name = $"Имя {i}",
                SurName = $"Фамилия {i}",
                Patronymic = $"Отчество {i}",
                DayOfBirth = DateTime.Now.Subtract(TimeSpan.FromDays(365 * rnd.Next(18, 50)))
            }))
            {
                _Employees.Add(employee);
            }
        }

        private RelayCommand testCommand;
        private Random rnd = new Random();

        public RelayCommand TestCommand
        {
            get
            {
                return testCommand ??
                    (testCommand = new RelayCommand(obj =>
                    {
                        //команда не запускается???????????????????
                        Debug.Fail("12312312312312312");
                    }));
            }
        }
    }
}
