using DepartamentManager.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartamentManager.ViewModels
{
    class DepartamentViewModel : ViewModel
    {
        public int Id { get; set; }
        private string _Name;
        public string Name
        {
            get => _Name;
            set => Set(ref _Name, value);
        }
    }
}
