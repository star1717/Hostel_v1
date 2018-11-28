using Host_v1.ViewModel.Commands;
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
    class LogViewModel : INotifyPropertyChanged
    {
        private Log selectedLog;
        public Model1 db;
        public ObservableCollection<Log> log { get; set; }
        public ObservableCollection<Client> clients { get; set; }
        //private Client selectedClient;
        public LogViewModel(Model1 db)
        {
            this.db = db;
            this.db.Log.Load();
            log = new ObservableCollection<Log>(this.db.Log);
            clients = new ObservableCollection<Client>(this.db.Clients);
        }
        public Client SelectedClient
        {
            get { return SelectedLog.Client; }
            set
            {
                //SelectedLog.ID_client_FK = value.ID_client;
                SelectedLog.Client = value;
                OnPropertyChanged("clients");
                OnPropertyChanged("SelectedClient");

            }
        }
        public Log SelectedLog
        {
            get { return selectedLog; }
            set
            {
                selectedLog = value;
                //selectedClient = selectedLog.Client;
                OnPropertyChanged("SelectedLog");
                OnPropertyChanged("SelectedClient");
            }
        }
        private ICommand saveLog;
        public ICommand SaveLog
        {
            get
            {
                if (saveLog == null)
                {
                    saveLog = new SaveLogCommand(this);
                }
                return saveLog;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
