﻿using Host_v1.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Host_v1.ViewModel
{
    class OpenReserveViewCommand : MyCommand<MainViewModel1>
    {
        public OpenReserveViewCommand(MainViewModel1 cvm) : base(cvm)
        {
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            ReserveView vm = new ReserveView(_cvm.db);
            vm.ShowDialog();
        }
    }
}
