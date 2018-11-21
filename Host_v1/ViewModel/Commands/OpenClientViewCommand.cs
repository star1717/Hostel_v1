using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Host_v1.ViewModel
{
    class OpenClientViewCommand : MyCommand<MainViewModel1>
    {
        public OpenClientViewCommand(MainViewModel1 cvm) : base(cvm)
        {
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            //var k = _cvm.DataContext as MainViewModel1;
            AddClient f = new AddClient(_cvm.db);
            f.ShowDialog();
        }
    }
}
