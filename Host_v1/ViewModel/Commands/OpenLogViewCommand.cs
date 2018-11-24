using Host_v1.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Host_v1.ViewModel.Commands
{
    class OpenLogViewCommand : MyCommand<MainViewModel1>
    {
        public OpenLogViewCommand(MainViewModel1 cvm) : base(cvm)
        {
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            LogView l = new LogView(_cvm.db);
            l.ShowDialog();
        }
    }
}
