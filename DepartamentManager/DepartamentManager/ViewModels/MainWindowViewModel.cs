using DepartamentManager.Command;
using DepartamentManager.Data;
using DepartamentManager.Infrastructure.Commands;
using DepartamentManager.Models;
using DepartamentManager.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

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

        private ObservableCollection<DepartamentViewModel> _Departamens;
        public ObservableCollection<DepartamentViewModel> Departamens
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
            _Departamens = new ObservableCollection<DepartamentViewModel>(
                Enumerable.Range(1, 10).Select(i => new DepartamentViewModel { Name = $"Отдел {i}" }));

            foreach (var employee in Enumerable.Range(1, 100).Select(i => new EmployeeViewModel()
            {
                Id = i,
                Name = $"Имя {i}",
                SurName = $"Фамилия {i}",
                Patronymic = $"Отчество {i}",
                DayOfBirth = DateTime.Now.Subtract(TimeSpan.FromDays(365 * rnd.Next(18, 50))),
                Departament = _Departamens[rnd.Next(1,10)]
            }))
                _Employees.Add(employee);

            #region Команды
            CreateNewEmployeeCommand = new LambdaCommand(OnCreateNewEmployeeCommandExecuted);
            RemoveEmployeeCommand = new LambdaCommand(OnRemoveEmployeeCommandExecuted, CanRemoveEmployeeCommandExecuted);
            #endregion
        }

        private RelayCommand testCommand;
        private Random rnd = new Random();


        #region Команды

        public ICommand CreateNewEmployeeCommand { get; }
        private void OnCreateNewEmployeeCommandExecuted(object parameter)
        {
            var new_employee = new EmployeeViewModel { Name = "New Employee" };
            _Employees.Insert(0,new_employee);
            SelectedEmployee = new_employee;
        }

        public ICommand RemoveEmployeeCommand { get; }
        private void OnRemoveEmployeeCommandExecuted(object parameter)
        {
            //приводим к типу EmployeeViewModel, если удачно то объект будет в employee, иначе выход
            if (!(parameter is EmployeeViewModel employee)) return;
            _Employees.Remove(employee);
            if (ReferenceEquals(_SelectedEmployee, employee))
                SelectedEmployee = null;
        }
        private bool CanRemoveEmployeeCommandExecuted(object parameter) => parameter is EmployeeViewModel;
        #endregion

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
