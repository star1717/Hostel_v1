using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Host_v1.ViewModel
{
    class SaveClientsCommand : MyCommand<ClientViewModel>
    {
        public SaveClientsCommand(ClientViewModel cvm) : base(cvm)
        {
        }

        public override bool CanExecute(object parameter)
        {
           return true;
           
        }
        public override void Execute(object parameter)
        {
            if (_cvm.SelectedClient != null)
            {
              var client = _cvm.db.Clients.Find(_cvm.SelectedClient.ID_client);
              if (client == null)
              {
               _cvm.db.Clients.Add( _cvm.SelectedClient);
              }
              
              _cvm.db.SaveChanges();
              MessageBox.Show("Изменения сохранены!");
            }
           else MessageBox.Show("Пожалуйста, выберете клиента из списка!");
        }
    }
}
