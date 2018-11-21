using Host_v1.ViewModel.Commands;
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
    public class ReserveViewModel : INotifyPropertyChanged           
    {
        public Model1 db;
        public ObservableCollection<Client> clients { get; set; }
        private Client selectedClient;

        public ObservableCollection<Kategory> kategory { get; set; }
        private Kategory selectedKatgory;
        
        private ObservableCollection<Number> numbers { get; set; }//all numbers
        private ObservableCollection<Number> numb;//номера с выбранным типом
        private Number selectedNumber;

        public ObservableCollection<Status> status { get; set; }
        private Status selectedStatus;

        public Uchet uchet { get; set; }

        public ObservableCollection<Worker> worker { get; set; }
        private Worker selectedWorker;

        //private DateTime Date_start;
        //private DateTime Date_finish;
        private string text_;
        public string text
        {
            get { return text_; }
            set
            {
                text_ = value;
                OnPropertyChanged("text");
            }
        }
        public ReserveViewModel(Model1 db)
        {
            this.db = db;
            clients = new ObservableCollection<Client>(db.Clients);
            kategory = new ObservableCollection<Kategory>(db.Kategory);
            numbers = new ObservableCollection<Number>(db.Number);
            status = new ObservableCollection<Status>(db.Status);
            uchet = new Uchet();
            worker = new ObservableCollection<Worker>(db.Worker);

        }
        private ICommand reserve;
        public ICommand Reserve
        {
            get
            {
                if (reserve == null)
                {
                    reserve = new ReserveCommand(this);
                }
                return reserve;
            }
        }
        //public DateTime date_start
        //{
        //    get { return Date_start; }
        //    set
        //    {
        //        Date_start = value;
        //        OnPropertyChanged("date_start");
        //    }
        //}

        //public DateTime date_finish
        //{
        //    get { return Date_finish; }
        //    set
        //    {
        //        Date_finish = value;
        //        OnPropertyChanged("date_finish");
        //    }
        //}
        public Status SelectedStatus
        {
            get { return selectedStatus; }
            set
            {
                selectedStatus = value;
                Numbers = new ObservableCollection<Number>(numbers.Where(u => u.Kategory == SelectedKatgory && u.Status==SelectedStatus).ToList());
                OnPropertyChanged("SelectedStatus");
            }
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

        public Number SelectedNumber
        {
            get { return selectedNumber; }
            set
            {
                selectedNumber = value;
                OnPropertyChanged("SelectedNumber");
            }
        }
        public ObservableCollection<Number> Numbers
        {
            get
            {                
                return numb;
            }
            set
            {
                numb = value;               
                OnPropertyChanged("Numbers");
            }
        }
        public Kategory SelectedKatgory
        {
            get { return selectedKatgory; }
            set
            {
                selectedKatgory = value;
                Numbers = new ObservableCollection<Number>(numbers.Where(u => u.Kategory == SelectedKatgory && u.Status == SelectedStatus).ToList());
                OnPropertyChanged("SelectedKatgory");
            }
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
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
