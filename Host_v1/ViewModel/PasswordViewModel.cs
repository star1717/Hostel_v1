using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Host_v1.ViewModel
{
    class PasswordViewModel : INotifyPropertyChanged
    {
        Model1 db;
        public Action CloseAction { get; set; }
        public ObservableCollection<Worker> workers { get; set; }
        private Worker worker;
        public PasswordViewModel(Model1 db)
        {
            this.db = db;
            workers = new ObservableCollection<Worker>(db.Worker);
            worker = new Worker();
        }
       
        public Worker Worker
        {
            get { return worker; }
            set
            {
                worker = value;
                OnPropertyChanged("Worker");
            }
        }
        private ICommand password;
        public ICommand Password
        {
            get
            {
                if (password == null)
                {
                    password = new PasswordCommand(this);
                }
                return password;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
