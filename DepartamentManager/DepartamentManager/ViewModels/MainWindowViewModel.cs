using DepartamentManager.Command;
using DepartamentManager.Data;
using DepartamentManager.Models;
using DepartamentManager.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartamentManager.ViewModels
{
    class MainWindowViewModel : ViewModel
    {
        public string Title { get; set; } = "Работа с департаментами и сотрудниками";


        private RelayCommand testCommand;
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
