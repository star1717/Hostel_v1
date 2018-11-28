using Host_v1.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Host_v1.ViewModel.Commands
{
    class OpenPasswordViewCommand : MyCommand<MainViewModel1>
    {
        public OpenPasswordViewCommand(MainViewModel1 cvm) : base(cvm)
        {
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {          
            Password vm = new Password();
            _cvm.CloseAction();
            vm.Show();
        }
    }
}
