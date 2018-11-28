using Host_v1.ViewModel;
using Host_v1.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Host_v1
{
    class MainViewModel1 : INotifyPropertyChanged
    {
        public Model1 db = new Model1();       
        public event PropertyChangedEventHandler PropertyChanged;
        private ICommand openNumbersView;
        public ICommand OpenNumbersView
        {
            get
            {
                if (openNumbersView == null)
                {
                    openNumbersView = new OpenNumbersViewCommand(this);
                }
                return openNumbersView;
            }
        }
        private ICommand openLogView;
        public ICommand OpenLogView
        {
            get
            {
                if (openLogView == null)
                {
                    openLogView = new OpenLogViewCommand(this);
                }
                return openLogView;
            }
        }

        private ICommand openClientView;
        public ICommand OpenClientView
        {
            get
            {
                if (openClientView == null)
                {
                    openClientView = new OpenClientViewCommand(this);
                }
                return openClientView;
            }
        }
        private ICommand openTypeNumberView;
        public ICommand OpenTypeNumberView
        {
            get
            {
                if (openTypeNumberView == null)
                {
                    openTypeNumberView = new OpenTypeNumberViewCommand(this);
                }
                return openTypeNumberView;
            }
        }

        private ICommand openReserveView;
        public ICommand OpenReserveView
        {
            get
            {
                if (openReserveView == null)
                {
                    openReserveView = new OpenReserveViewCommand(this);
                }
                return openReserveView;
            }
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
