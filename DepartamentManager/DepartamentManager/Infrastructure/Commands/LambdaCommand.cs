using System;
using DepartamentManager.Infrastructure.Commands;

namespace DepartamentManager.Infrastructure.Commands
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
