using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieGame.Infrastructure.Commands
{
    class LambdaCommand : Infrastructure.Commands.Base.Command
    {
        private Action<object> _Execute;
        private Func<object, bool> _CanExecute;

        public LambdaCommand(Action<object> Execute, Func<object, bool> CanExecute = null)
        {
            if (Execute is null)
                throw new ArgumentNullException(nameof(Execute));
            _Execute = Execute;
            _CanExecute = CanExecute;
        }

        public override bool CanExecute(object parameter)
        {
            return _CanExecute?.Invoke(parameter) ?? true;
        }
        public override void Execute(object parameter)
        {
            _Execute(parameter);
        }
    }
}
