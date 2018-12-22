using Host_v1.Interfaces;
using Host_v1.View;
using Host_v1.ViewModel;

using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace Host_v1
{
    class MainViewModel1 : INotifyPropertyChanged, IRequireViewIdentification
    {
        public Model1 db;
        public ObservableCollection<Uchet> uchets { get; set; }
        private bool[] flag;
        private DispatcherTimer timer;
        private DateTime date;
        public Guid ViewID { get; }
        public MainViewModel1(Model1 db)
        {
            this.db = db;
            date = DateTime.Now;
            ViewID = Guid.NewGuid();
            uchets = new ObservableCollection<Uchet>(db.Uchet);
            flag = new bool[db.Number.Count()];
            foreach (var obj in uchets)
            {
                if (DateTime.Today >= obj.Date_start && DateTime.Today <= obj.Date_finish && !flag[obj.Number.ID - 1]) { obj.Number.Status1 = db.Status.Find(2); flag[obj.Number.ID - 1] = true; }
                else if (obj.Number.Status != db.Status.Find(4)) obj.Number.Status1 = db.Status.Find(1);
            }            
            timer = new DispatcherTimer(); 
            timer.Tick += new EventHandler(timerTick);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
        }
        private void timerTick(object sender, EventArgs e)
        {
            if (DateTime.Now.Day != date.Day)
            {        
                for (int i=0;i< db.Number.Count(); i++)
                {
                    flag[i] = false;
                }
                foreach (var obj in uchets)
                {
                   if (DateTime.Today >= obj.Date_start && DateTime.Today <= obj.Date_finish && !flag[obj.Number.ID - 1]) { obj.Number.Status1 = db.Status.Find(2); flag[obj.Number.ID - 1] = true; }
                   else if (obj.Number.Status != db.Status.Find(4)) obj.Number.Status1 = db.Status.Find(1);
                }
            }
  
        }                        
        public event PropertyChangedEventHandler PropertyChanged;

        private RelayCommand openServiceView;
        public RelayCommand OpenServiceView
        {
            get
            {
                return openServiceView ??
                    (openServiceView = new RelayCommand(obj =>
                    {
                        ServiceView l = new ServiceView();
                        l.DataContext=new ServiceViewModel(db);
                        l.ShowDialog();
                    }));
            }
        }


        private RelayCommand openUchetView;
        public RelayCommand OpenUchetView
        {
            get
            {
                return openUchetView ??
                    (openUchetView = new RelayCommand(obj =>
                    {
                        UchetView l = new UchetView();
                        l.DataContext = new UchetViewModel(db);
                        l.ShowDialog();
                    }));
            }
        }

        private RelayCommand openPasswordView;
        public RelayCommand OpenPasswordView
        {
            get
            {
                return openPasswordView ??
                    (openPasswordView = new RelayCommand(obj =>
                    {
                        Password vm = new Password();                                   
                        vm.Show();
                        WindowManager.CloseWindow(ViewID);  
                    }));
            }
        }

        private RelayCommand openNumbersView;
        public RelayCommand OpenNumbersView
        {
            get
            {
                return openNumbersView ??
                    (openNumbersView = new RelayCommand(obj =>
                    {
                        NumbersView l = new NumbersView();
                        l.DataContext = new NumbersViewModel(db);
                        l.ShowDialog();
                    }));
            }
        }       
        private RelayCommand openPayView;
        public RelayCommand OpenPayView
        {
            get
            {
                return openPayView ??
                    (openPayView = new RelayCommand(obj =>
                    {
                        PayView l = new PayView();
                        l.DataContext = new PayViewModel(db);
                        l.ShowDialog();
                    }));
            }
        }
        private RelayCommand openLogView;
        public RelayCommand OpenLogView
        {
            get
            {
                return openLogView ??
                    (openLogView = new RelayCommand(obj =>
                    {
                        LogView l = new LogView();
                        l.DataContext = new LogViewModel(db);
                        l.ShowDialog();
                    }));
            }
        }

        private RelayCommand openClientView;
        public RelayCommand OpenClientView
        {
            get
            {
                return openClientView ??
                    (openClientView = new RelayCommand(obj =>
                    {
                        AddClient f = new AddClient();
                        ClientViewModel vm = new ClientViewModel(db);
                        ViewShower.Show(0, vm);
                        //f.DataContext = new ClientViewModel(db);
                        //f.ShowDialog();
                    }));
            }
        }

        private RelayCommand openTypeNumberView;
        public RelayCommand OpenTypeNumberView
        {
            get
            {
                return openTypeNumberView ??
                    (openTypeNumberView = new RelayCommand(obj =>
                    {
                       TypeNumber t = new TypeNumber();
                        t.DataContext = new TypeNumberViewModel(db, new DefaultDialogService());
                        t.ShowDialog();
                    }));
            }
        }

        private RelayCommand openReserveView;
        public RelayCommand OpenReserveView
        {
            get
            {
                return openReserveView ??
                    (openReserveView = new RelayCommand(obj =>
                    {
                        ReserveView vm = new ReserveView();
                        vm.DataContext = new ReserveViewModel(db);
                        vm.ShowDialog();
                    }));
            }
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
