using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Host_v1.ViewModel
{
    class ReportViewModel : INotifyPropertyChanged
    {
        public Model1 db;
        public ObservableCollection<Uchet> uchet;
        public ObservableCollection<Uchet> report;
        public ReportViewModel(Model1 db)
        {
            this.db = db;           
            uchet = new ObservableCollection<Uchet>(db.Uchet.Local);
            report = new ObservableCollection<Uchet>();
        }
        private DateTime selectedDateStart;
        public DateTime SelectedDateStart
        {
            get { return selectedDateStart; }
            set
            {
                selectedDateStart = value;
                OnPropertyChanged("SelectedDateStart");
            }
        }
        private DateTime selectedDateFinish;
        public DateTime SelectedDateFinish
        {
            get { return selectedDateStart; }
            set
            {
                selectedDateFinish = value;
                OnPropertyChanged("SelectedDateFinish");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
