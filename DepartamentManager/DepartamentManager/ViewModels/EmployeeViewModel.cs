using DepartamentManager.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartamentManager.ViewModels
{
    class EmployeeViewModel : ViewModel
    {
        public int Id { get; set; }

        private string _Name;
        public string Name
        {
            get => _Name;
            set => Set(ref _Name, value);
        }

        private string _SurName;
        public string SurName
        {
            get => _SurName;
            set => Set(ref _SurName, value);
        }

        private string _Patronymic;
        public string Patronymic
        {
            get => _Patronymic;
            set => Set(ref _Patronymic, value);
        }

        private DateTime _DayOfBirth;
        public DateTime DayOfBirth
        {
            get => _DayOfBirth;
            set
            {
                if (Set(ref _DayOfBirth, value))
                    OnPropertyChanged(nameof(Age));
            }
        }
        public int Age => (int)Math.Floor((DateTime.Now - DayOfBirth).TotalDays / 365);

    }
}
