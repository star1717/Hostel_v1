using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
            clients = new ObservableCollection<Client>(db.Clients);
            clients.OrderBy(u => u.FIO);
            SelectedClient=db.Clients.FirstOrDefault();
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

        private RelayCommand addClient;
        public RelayCommand AddClient
        {
            get
            {
                return addClient ??
                    (addClient = new RelayCommand(obj =>
                    {
                        Client client = new Client() { Fio = "Новый клиент" , Birth=DateTime.Now};
                        clients.Insert(0, client);
                        SelectedClient = client;
                        MessageBox.Show("Новый объект добавлен!");
                    }));
            }
        }
        private RelayCommand removeClient;
        public RelayCommand RemoveClient
        {
            get
            {
                return removeClient ??
                    (removeClient = new RelayCommand(obj =>
                    {

                        if (db.Clients.Find(SelectedClient.ID_client) != null)
                        {
                            db.Clients.Remove(SelectedClient);
                            clients.Remove(SelectedClient);
                            db.SaveChanges();                          
                        }
                        else clients.Remove(SelectedClient);
                        MessageBox.Show("Объект удален!");                                 
                    },
                    (obj) => SelectedClient != null));
            }
        }

        private RelayCommand saveClients;
        public RelayCommand SaveClients
        {
            get
            {
                return saveClients ??
                    (saveClients = new RelayCommand(obj =>
                    {
                        if (SelectedClient != null)
                        {
                            var client = db.Clients.Find(SelectedClient.ID_client);
                            if (client == null)
                            {
                                db.Clients.Add(SelectedClient);
                            }
                            db.SaveChanges();
                            MessageBox.Show("Изменения сохранены!");
                        }
                        else MessageBox.Show("Пожалуйста, выберете клиента из списка!");
                    },obj=>CanExecuteSave()));     
            }
        }
        private bool CanExecuteSave()
        {
            if (SelectedClient != null)
            {
                if (SelectedClient.Fio.TrimEnd() != "Новый клиент" && SelectedClient.Number != null && SelectedClient.Passport != null) return true;               
            }
            return false;

        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
