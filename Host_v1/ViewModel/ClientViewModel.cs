using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Host_v1.ViewModel
{
    class ClientViewModel : INotifyPropertyChanged
    {
        public Model1 db;
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Client> clients { get; set; }
        private Client selectedClient;

        public ClientViewModel(Model1 db)
        {
            this.db = db;
            db.Clients.Load();
            clients = new ObservableCollection<Client>(db.Clients);
        }

        public Client SelectedClient
        {
            get { return selectedClient; }
            set
            {
                selectedClient = value;

                OnPropertyChanged("SelectedClient");
            }
        }
        private ICommand addClient;
        public ICommand AddClient
        {
            get
            {
                if (addClient == null)
                {
                    addClient = new AddClientCommand(this);

                }
                return addClient;
            }
        }
        private ICommand removeClient;
        public ICommand RemoveClient
        {
            get
            {
                if (removeClient == null)
                {
                    removeClient = new RemoveClientCommand(this);
                }
                return removeClient;
            }
        }

        private ICommand saveClients;
        public ICommand SaveClients
        {
            get
            {
                if (saveClients == null)
                {
                    saveClients = new SaveClientsCommand(this);
                }
                return saveClients;
            }
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
