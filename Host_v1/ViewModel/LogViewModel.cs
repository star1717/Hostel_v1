
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
    class LogViewModel : INotifyPropertyChanged
    {
        private Log selectedLog;
        public Model1 db;
        public ObservableCollection<Log> log { get; set; }
        public ObservableCollection<Client> clients { get; set; }
        public ObservableCollection<Service> services { get; set; }
        public LogViewModel(Model1 db)
        {
            this.db = db;
            this.db.Log.Load();
            log = new ObservableCollection<Log>(this.db.Log);
            clients = new ObservableCollection<Client>(this.db.Clients);
            services = new ObservableCollection<Service>(this.db.Service);
            SelectedLog=db.Log.FirstOrDefault();
        }

        public Log SelectedLog
        {
            get { return selectedLog; }
            set
            {
                selectedLog = value;
                OnPropertyChanged("SelectedLog");

            }
        }
        private RelayCommand removeLog;
        public RelayCommand RemoveLog
        {
            get
            {
                return removeLog ??
                    (removeLog = new RelayCommand(obj =>
                    {

                        if (db.Log.Find(SelectedLog.ID_line) != null)
                        {
                            db.Log.Remove(SelectedLog);
                            log.Remove(SelectedLog);
                            db.SaveChanges();
                            MessageBox.Show("Объект удален!");
                        }
                        else log.Remove(SelectedLog);
                    },
                    (obj) => SelectedLog != null));
            }
        }
        private RelayCommand addLog;
        public RelayCommand AddLog
        {
            get
            {
                return addLog ??
                    (addLog = new RelayCommand(obj =>
                    {
                        Log _log = new Log() {Client1=new Client() { Fio="Новый объект"} };
                        log.Insert(0,_log);
                        SelectedLog = _log;
                        MessageBox.Show("Новый объект добавлен!");
                    }));
            }
        }
        private RelayCommand saveLog;
        public RelayCommand SaveLog
        {
            get
            {
                return saveLog ??
                    (saveLog = new RelayCommand(obj =>
                    {
                        try
                        {
                          if (SelectedLog != null)
                          {
                            var log = db.Log.Find(SelectedLog.ID_line);
                            if (log == null)
                            {
                                db.Log.Add(SelectedLog);
                            }
                         
                            db.SaveChanges();
                            MessageBox.Show("Изменения сохранены!");
                          }
                          else MessageBox.Show("Пожалуйста, выберете запись из списка!");
                        }
                        catch
                        {
                            MessageBox.Show("Невозможно изменить объект!");
                        }

                    }));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
