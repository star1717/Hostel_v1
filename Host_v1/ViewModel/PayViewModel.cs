
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
    class PayViewModel: INotifyPropertyChanged
    {
        public Model1 db;      
        public ObservableCollection<Client> clients { get; set; }
        private int costUchet { get; set; }
        private int costLog { get; set; }
        private int sum;
        public PayViewModel(Model1 db)
        {
            this.db = db;
            clients = new ObservableCollection<Client>(db.Clients);
            Date = DateTime.Now;
            //Uchets = new ObservableCollection<Uchet>(db.Uchet.Where(u => u.Pay != null).ToList());
        }
        private bool chekUchet;
        public bool ChekUchet
        {
            get { return chekUchet; }
            set
            {
                chekUchet = value;
                SetCostUchet();
                SetSum();
                OnPropertyChanged("ChekUchet");
            }
        }
        private bool radioBut;
        public bool RadioBut
        {
            get { return radioBut; }
            set
            {
                radioBut = value;
                SetCostLog();
                SetSum();
                OnPropertyChanged("RadioButUchet");
            }
        }
        private bool chekService;
        public bool ChekService
        {
            get { return chekService; }
            set
            {
                chekService = value;
                SetCostLog();
                SetSum();
                OnPropertyChanged("ChekService");
            }
        }
        
        public int Sum
        {
            get { return sum; }
            set
            {
                sum = value;
                OnPropertyChanged("Sum");
            }
        }
        public int CostUchet
        {
            get { return costUchet; }
            set
            {
                costUchet = value;
                OnPropertyChanged("CostUchet");
            }
        }
        public int CostLog
        {
            get { return costLog; }
            set
            {
                costLog = value;
                OnPropertyChanged("CostLog");
            }
        }
        private Client selectedClient;
        public Client SelectedClient
        {
            get { return selectedClient; }
            set
            {
                selectedClient = value;
                OnPropertyChanged("SelectedClient");
            }
        }
        
        private Log selectedLog;
        public Log SelectedLog
        {
            get { return selectedLog; }
            set
            {
                selectedLog = value;

                SetCostLog();
    
                SetSum();
                OnPropertyChanged("SelectedLog");
            }
        }
        private void SetSum()
        {
            Sum = CostLog + CostUchet;
        }
        private void SetCostLog()
        {
            CostLog = 0;
            if (ChekService)
            {
                if (RadioBut)
                {
                    foreach (var item in SelectedClient.Log)
                    {
                        CostLog += item.Service1.Pay;
                    }
                }
                else CostLog = selectedLog.Service1.Pay;
            }
        }
        private void SetCostUchet()
        {
            CostUchet = 0;
            if (ChekUchet)
            {

                CostUchet = selectedUchet.Number1.Kategory1.Cost * (selectedUchet.date_finish - selectedUchet.date_start).Days;
                if (CostUchet == 0) CostUchet = selectedUchet.Number1.Kategory1.Cost;
            }
          
        }
        private Uchet selectedUchet;
        public Uchet SelectedUchet
        {
            get { return selectedUchet; }
            set
            {
                selectedUchet = value;
                SetCostUchet();
                SetSum();            
                OnPropertyChanged("SelectedUchet");
            }
        }
        private DateTime date;
        public DateTime Date
        {
            get { return date; }
            set
            {
                date = value;
                OnPropertyChanged("Date");
            }
        }

        private RelayCommand payAccommodation;
        public RelayCommand PayAccommodation
        {
            get
            {
                return payAccommodation ??
                    (payAccommodation = new RelayCommand(obj =>
                    {
                        if (ChekUchet)
                        {
                            if (SelectedUchet == null)
                            {
                              Pay pay = new Pay();
                              pay.Date = Date;
                              pay.Client1 = SelectedClient;
                              pay.Sum = this.Sum;
                              db.Pay.Add(pay);
                              SelectedUchet.Pay1=pay;
                              db.SaveChanges();
                              MessageBox.Show("Проживание оплачено!");
                            }
                            else MessageBox.Show("Пожалуйста, заполните все поля!");
                        }
                        if (ChekService)
                        {
                            if (RadioBut)
                            {
                                foreach(var item in SelectedClient.Log)
                                {
                                    Pay pay = new Pay();
                                    pay.Date = Date;
                                    pay.Client1 = SelectedClient;
                                    pay.Sum = item.Service1.Pay;
                                    db.Pay.Add(pay);
                                    item.Pay = pay;
                                }
                                db.SaveChanges();
                                MessageBox.Show("Все услуги оплачены!");
                            }
                            else
                            {
                                Pay pay = new Pay();
                                pay.Date = Date;
                                pay.Client1 = SelectedClient;
                                pay.Sum = SelectedLog.Service1.Pay;
                                db.Pay.Add(pay);
                                SelectedLog.Pay = pay;
                                db.SaveChanges();
                                MessageBox.Show("Услуга оплачена!");
                            }

                        }
                    },obj=>CanExecute()));
            }
        }
        private bool CanExecute()
        {
            if (ChekService && ChekUchet) return (SelectedUchet != null && SelectedLog != null);
            else if (ChekUchet) return (SelectedUchet != null);
            else if (ChekService) return(SelectedLog != null);
            return false;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
