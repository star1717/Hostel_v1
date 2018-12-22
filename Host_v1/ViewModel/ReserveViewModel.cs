using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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

        public ObservableCollection<Uchet> uchets { get; set; }
        //private bool[] flag;

        public ObservableCollection<Worker> worker { get; set; }
        private Worker selectedWorker;

        public int Sum { get; set; }

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
            uchet = new Uchet() { Date_start=DateTime.Now, Date_finish=DateTime.Now};
            worker = new ObservableCollection<Worker>(db.Worker);
            uchets = new ObservableCollection<Uchet>(db.Uchet);
        }

        private RelayCommand reserve;
        public RelayCommand Reserve
        {
            get
            {
                return reserve ??
                    (reserve = new RelayCommand(obj =>
                    {
                        var items = db.Uchet.Where(u => u.ID_number_FK == SelectedNumber.ID);
                        foreach (var item in items) { if (item.date_start <= uchet.date_start && uchet.date_start <= item.date_finish) { text = "Выбранный вами номер забронирован на этот период!"; return; } }
                        if (SelectedClient != null)
                        {
                            if (SelectedNumber != null)
                            {
                                if (SelectedWorker != null)
                                {
                                    if (uchet.Date_start < uchet.Date_finish)
                                    {
                                        var client = db.Clients.Find(SelectedClient.ID_client);
                                        var number = db.Number.Find(SelectedNumber.ID_number);
                                        var worker = db.Worker.Find(SelectedWorker.ID_worker);
                                        var uchett = new Uchet()
                                        {
                                            ID_client_FK = client.ID_client,
                                            ID_number_FK = number.ID_number,
                                            ID_worker_FK = worker.ID_worker,
                                            Date_start = uchet.date_start,
                                            Date_finish = uchet.date_finish
                                        };
                                        if (uchet.Date_start <= DateTime.Today && DateTime.Today <= uchet.Date_finish) number.Status1 = db.Status.Find(2);
                                        db.Uchet.Add(uchett);
                                        db.SaveChanges();
                                        text = "";
                                        MessageBox.Show("Номер забронирован!");
                                        //_cvm.SelectedClient = null;
                                        //_cvm.SelectedNumber = null;
                                        //_cvm.SelectedWorker = null;
                                        //_cvm.SelectedKatgory = null;
                                        //_cvm.SelectedStatus = null;
                                    }
                                    else text = "Период проживания указан неправильно!";
                                }
                                else text = "Пожалуйста, выберете администратора, работающего в системе!";
                            }
                            else text = "Пожалуйста, выберете номер для бронирования!";
                        }
                        else text = "Пожалуйста, выберете клиента!";
                    }));
            }
        }
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
                Sum = SelectedKatgory.Cost * (uchet.date_finish - uchet.date_start).Days;
                OnPropertyChanged("SelectedKatgory");
                OnPropertyChanged("Sum");

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
