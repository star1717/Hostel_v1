using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Host_v1.ViewModel
{
    class TypeNumberViewModel : INotifyPropertyChanged
    {
        public Model1 db;
        public ObservableCollection<Kategory> kategory { get; set; }
        public TypeNumberViewModel(Model1 db)
        {
            this.db = db;
            kategory = new ObservableCollection<Kategory>(db.Kategory);
        }
        private Kategory selectedKategory;
        public Kategory SelectedKategory
        {
            get { return selectedKategory; }
            set
            {
                selectedKategory = value;
                OnPropertyChanged("SelectedKategory");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
