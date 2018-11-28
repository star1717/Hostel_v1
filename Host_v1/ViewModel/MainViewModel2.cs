using Host_v1.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Host_v1.ViewModel
{
    class MainViewModel2 : INotifyPropertyChanged
    {
        public Model1 db;
        public MainViewModel2(Model1 db)
        {
            this.db = db;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public Action CloseAction { get; set; }
        private ICommand openPasswordView;
        public ICommand OpenPasswordView
        {
            get
            {
                if (openPasswordView == null)
                {
                    openPasswordView = new OpenPasswordViewCommand2(this);
                }
                return openPasswordView;
            }
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
