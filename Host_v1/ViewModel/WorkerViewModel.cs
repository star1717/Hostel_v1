using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Host_v1.ViewModel
{
    class WorkerViewModel : INotifyPropertyChanged
    {
        Model1 db;
        private Worker selectedWorker;
        public ObservableCollection<Worker> workers { get; set; }
        public WorkerViewModel(Model1 db)
        {
            this.db = db;
            workers = new ObservableCollection<Worker>(db.Worker);
            SelectedWorker=db.Worker.FirstOrDefault();
        }
        public Worker SelectedWorker
        {
            get { return selectedWorker; }
            set
            {
                selectedWorker = value;
                OnPropertyChanged("SelectedWorker");
            }
        }
        private RelayCommand addWorker;
        public RelayCommand AddWorker
        {
            get
            {
                return addWorker ??
                    (addWorker = new RelayCommand(obj =>
                    {
                        Worker worker = new Worker() { Fio = "Новый сотрудник", Birth=DateTime.Now };
                        workers.Insert(0, worker);
                        SelectedWorker = worker;
                        MessageBox.Show("Новый сотрудник добавлен!");
                    }));
            }
        }
        private RelayCommand removeWorker;
        public RelayCommand RemoveWorker
        {
            get
            {
                return removeWorker ??
                    (removeWorker = new RelayCommand(obj =>
                    {

                        if (db.Worker.Find(SelectedWorker.ID_worker) != null)
                        {
                            db.Worker.Remove(SelectedWorker);
                            workers.Remove(SelectedWorker);
                            db.SaveChanges();
                            MessageBox.Show("Объект удален!");
                        }
                        else workers.Remove(SelectedWorker);
                    },
                    (obj) => SelectedWorker != null));
            }
        }

        private RelayCommand saveWorker;
        public RelayCommand SaveWorker
        {
            get
            {
                return saveWorker ??
                    (saveWorker = new RelayCommand(obj =>
                    {
                    
                            var Worker = db.Worker.Find(SelectedWorker.ID_worker);
                            if (Worker == null)
                            {
                                db.Worker.Add(SelectedWorker);
                            }
                            db.SaveChanges();
                            MessageBox.Show("Изменения сохранены!");
                        
                       
                    },
                    (obj) => (SelectedWorker != null) && SelectedWorker.Fio.TrimEnd() != "Новый сотрудник" && SelectedWorker.Number != null && SelectedWorker.Passport != null));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
