
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
    class NumbersViewModel : INotifyPropertyChanged
    {
        public Model1 db;
        public ObservableCollection<Kategory> kategory { get; set; }


        public ObservableCollection<Number> numbers { get; set; }//all numbers
        private Number selectedNumber;

        public ObservableCollection<Status> status { get; set; }


        public Number SelectedNumber
        {
            set
            {
                selectedNumber = value;
                OnPropertyChanged("SelectedNumber");
            }
            get { return selectedNumber; }
        }
        public NumbersViewModel(Model1 db)
        {
            this.db = db;
            numbers = new ObservableCollection<Number>(db.Number);
            numbers.OrderBy(u => u.ID);
            kategory = new ObservableCollection<Kategory>(db.Kategory);
            status = new ObservableCollection<Status>(db.Status);
            SelectedNumber = db.Number.FirstOrDefault();
        }
        private RelayCommand addNumber;
        public RelayCommand AddNumber
        {
            get
            {
                return addNumber ??
                    (addNumber = new RelayCommand(obj =>
                    {
                        Number number = new Number();
                        numbers.Insert(0, number);
                        SelectedNumber = number;
                        MessageBox.Show("Новая номер добавлен!");
                    }));
            }
        }
        private RelayCommand removeNumber;
        public RelayCommand RemoveNumber
        {
            get
            {
                return removeNumber ??
                    (removeNumber = new RelayCommand(obj =>
                    {

                        if (db.Number.Find(SelectedNumber.ID) != null)
                        {
                            db.Number.Remove(SelectedNumber);
                            numbers.Remove(SelectedNumber);
                            db.SaveChanges();
                            MessageBox.Show("Объект удален!");
                        }
                        else numbers.Remove(SelectedNumber);
                    },
                    (obj) => SelectedNumber != null));
            }
        }

        private RelayCommand saveNumber;
        public RelayCommand SaveNumber
        {
            get
            {
                return saveNumber ??
                    (saveNumber = new RelayCommand(obj =>
                    {
                        Number number=new Number();
                        try
                        {
                            if (SelectedNumber != null)
                            {
                                 number = db.Number.Find(SelectedNumber.ID);
                                if (number == null)
                                {
                                    db.Number.Add(SelectedNumber);
                                }
                                db.SaveChanges();
                                MessageBox.Show("Изменения сохранены!");
                            }
                        }
                        catch
                        {
                         
                            MessageBox.Show("Невозможно изменить объект!");
                        }

                    }, (obj) => (SelectedNumber != null) && SelectedNumber.Status1 != null && SelectedNumber.Kategory1 != null));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
