using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Host_v1.ViewModel;

namespace Host_v1
{
    abstract class MyCommand<T> : ICommand
    {
        protected T _cvm;
        //protected ClientViewModel cvm;

        public MyCommand(T cvm)
        {
            _cvm = cvm;
        }

        //public MyCommand(ClientViewModel cvm)
        //{
        //    this.cvm = cvm;
        //}

        public event EventHandler CanExecuteChanged;
        public abstract bool CanExecute(object parameter);
        public abstract void Execute(object parameter);
    }
}
