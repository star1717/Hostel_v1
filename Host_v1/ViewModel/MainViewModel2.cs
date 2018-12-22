using Host_v1.Interfaces;
using Host_v1.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Host_v1.ViewModel
{
    class MainViewModel2 : INotifyPropertyChanged, IRequireViewIdentification
    {
        public Model1 db;
        public MainViewModel2(Model1 db)
        {
            this.db = db;
            ViewID = Guid.NewGuid();
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private RelayCommand openPasswordView;
        public RelayCommand OpenPasswordView
        {
            get
            {
                return openPasswordView ??
                    (openPasswordView = new RelayCommand(obj =>
                    {
                        Password vm = new Password();
                        WindowManager.CloseWindow(ViewID);
                        vm.Show();
                    }));
            }
        }
        private RelayCommand openReportView;
        public RelayCommand OpenReportView
        {
            get
            {
                return openReportView ??
                    (openReportView = new RelayCommand(obj =>
                    {
                        ReportView vm = new ReportView();
                        vm.DataContext =new ReportViewModel(db);
                        vm.Show();
                    }));
            }
        }
        private RelayCommand openWorkerView;
        public RelayCommand OpenWorkerView
        {
            get
            {
                return openWorkerView ??
                    (openWorkerView = new RelayCommand(obj =>
                    {
                        WorkerView vm = new WorkerView();
                        vm.DataContext = new WorkerViewModel(db);
                        vm.Show();
                    }));
            }
        }

        public Guid ViewID { get; }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
