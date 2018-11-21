using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Host_v1.ViewModel;

namespace Host_v1
{
    class AddClientCommand : MyCommand<ClientViewModel>
    {
        //private ClientViewModel clientViewModel;

        public AddClientCommand(ClientViewModel cvm) : base(cvm)
        {
        }

        public override bool CanExecute(object parameter)
        {        
                return true;            
        }
        public override void Execute(object parameter)
        {
            Client client = new Client();                  
            _cvm.clients.Add(client);           
            MessageBox.Show("Новый объект добавлен!");
        }
    }
}
