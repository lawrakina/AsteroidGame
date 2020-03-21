using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZombieGame.ViewModels.Base;

namespace ZombieGame.ViewModels
{
    class MainWindowViewModel : ViewModel
    {
        private UserVM _UserVM;
        public UserVM UserVM
        {
            get => _UserVM;
            set => Set(ref _UserVM, value);
        }
    }
}
