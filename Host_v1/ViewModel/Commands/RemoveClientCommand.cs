using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Host_v1.ViewModel
{
    class RemoveClientCommand : MyCommand<ClientViewModel>
    {
        public RemoveClientCommand(ClientViewModel cvm) : base(cvm)
        {
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            try
            {
                if (_cvm.SelectedClient != null)
                {
                    _cvm.db.Clients.Remove(_cvm.SelectedClient);
                    _cvm.clients.Remove(_cvm.SelectedClient);
                    _cvm.db.SaveChanges();
                    MessageBox.Show("Объект удален!");
                }
            }

            catch
            {
                MessageBox.Show("Объект не может быть удален!");
            }
        }
    }
}
