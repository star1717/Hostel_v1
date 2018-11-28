using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Host_v1.ViewModel
{
    class NumbersViewModel : INotifyPropertyChanged
    {
        public Model1 db;
        public ObservableCollection<Kategory> kategory { get; set; }
        private Kategory selectedKatgory;

        public ObservableCollection<Number> numbers { get; set; }//all numbers
        private Number selectedNumber;

        public ObservableCollection<Status> status { get; set; }
        private Status selectedStatus;

        public Number SelectedNumber
        {
            set
            {
                selectedNumber = value;
                OnPropertyChanged("SelectedNumber");
            }
            get { return selectedNumber; }
        }
        public NumbersViewModel(Model1 db)
        {
            this.db = db;
            numbers = new ObservableCollection<Number>(db.Number);
            kategory = new ObservableCollection<Kategory>(db.Kategory);
            status = new ObservableCollection<Status>(db.Status);
        }
        public Status SelectedStatus
        {
            get { return selectedStatus; }
            set
            {
                selectedStatus = value;    
                OnPropertyChanged("SelectedStatus");
            }
        }
        public Kategory SelectedKatgory
        {
            get { return selectedKatgory; }
            set
            {
                selectedKatgory = value;
                OnPropertyChanged("SelectedKatgory");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
