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
    class UchetViewModel : INotifyPropertyChanged
    {
        public Model1 db;
        public ObservableCollection<Uchet> Uchets { get; set; }
        public ObservableCollection<Worker> Workers { get; set; }
        public ObservableCollection<Client> Clients { get; set; }
        public ObservableCollection<Number> Numbers { get; set; }
        private Uchet selectedUchet;
        public Uchet SelectedUchet
        {
            get { return selectedUchet; }
            set
            {
                selectedUchet = value;
                OnPropertyChanged("SelectedUchet");
            }
        }
        public UchetViewModel(Model1 db)
        {
            this.db = db;
            Uchets = new ObservableCollection<Uchet>(db.Uchet.OrderBy((u)=>u.Client.FIO));
            Workers = new ObservableCollection<Worker>(db.Worker);
            Clients = new ObservableCollection<Client>(db.Clients);
            Numbers = new ObservableCollection<Number>(db.Number);
            SelectedUchet = db.Uchet.FirstOrDefault();
        }
        private RelayCommand addUchet;
        public RelayCommand AddUchet
        {
            get
            {
                return addUchet ??
                    (addUchet = new RelayCommand(obj =>
                    {
                        Uchet uchet = new Uchet() { Date_start = DateTime.Now, Date_finish = DateTime.Now};
                        Uchets.Insert(0, uchet);
                        SelectedUchet = uchet;
                        MessageBox.Show("Новый объект обавлен!");
                    }));
            }
        }
        private RelayCommand removeUchet;
        public RelayCommand RemoveUchet
        {
            get
            {
                return removeUchet ??
                    (removeUchet = new RelayCommand(obj =>
                    {

                        if (db.Uchet.Find(SelectedUchet.ID_ychet) != null)
                        {
                            db.Uchet.Remove(SelectedUchet);
                            Uchets.Remove(SelectedUchet);
                            db.SaveChanges();
                            MessageBox.Show("Объект удален!");
                        }
                        else Uchets.Remove(SelectedUchet);
                    },
                (obj) => SelectedUchet != null));
            }
        }
        private RelayCommand saveUchet;
        public RelayCommand SaveUchet
        {
            get
            {
                return saveUchet ??
                    (saveUchet = new RelayCommand(obj =>
                    {

                        var uchet = db.Uchet.Find(SelectedUchet.ID_ychet);
                        if (uchet == null)
                        {
                            db.Uchet.Add(SelectedUchet);
                        }
                        db.SaveChanges();
                        MessageBox.Show("Изменения сохранены!");
                    },
                    (obj) => (SelectedUchet != null) && SelectedUchet.Client1 != null && SelectedUchet.Number1 != null && SelectedUchet.Worker1 != null));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
