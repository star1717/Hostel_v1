using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Host_v1.ViewModel
{
    class LogViewModel : INotifyPropertyChanged
    {
        private Log selectedLog;
        public ObservableCollection<Log> log { get; set; }
        public ObservableCollection<Client> clients { get; set; }
        //private Client selectedClient;
        public LogViewModel(Model1 db)
        {
            db.Log.Load();
            log = new ObservableCollection<Log>(db.Log);
            clients = new ObservableCollection<Client>(db.Clients);
        }
        public Client SelectedClient
        {
            get { return SelectedLog.Client; }
            set
            {
                SelectedLog.Client = value;
                OnPropertyChanged("SelectedLog");
                OnPropertyChanged("SelectedClient");

            }
        }
        public Log SelectedLog
        {
            get { return selectedLog; }
            set
            {
                selectedLog = value;
                SelectedClient = selectedLog.Client;
                OnPropertyChanged("SelectedLog");
                OnPropertyChanged("SelectedClient");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
