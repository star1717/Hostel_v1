using Host_v1.Interfaces;

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
    class TypeNumberViewModel : INotifyPropertyChanged
    {
        public DbOperations db;
        public ObservableCollection<Kategory> kategory { get; set; }
        public IDialogService ds;
        public TypeNumberViewModel(DbOperations db, IDialogService ds)
        {
            this.db = db;
            this.ds = ds;
            kategory = new ObservableCollection<Kategory>(db.GetAllKategory());
            SelectedKategory=db.GetAllKategory().FirstOrDefault();
        }
        private RelayCommand addKategory;
        public RelayCommand AddKategory
        {
            get
            {
                return addKategory ??
                    (addKategory = new RelayCommand(obj =>
                    {
                        Kategory type = new Kategory() { Name="Новая категория" };
                        kategory.Insert(0, type);
                        SelectedKategory = type;
                        ds.ShowMessage("Новый тип добавлен!");
                    }));
            }
        }
        private RelayCommand removeKategory;
        public RelayCommand RemoveKategory
        {
            get
            {
                return removeKategory ??
                    (removeKategory = new RelayCommand(obj =>
                    {

                        if (db.FindWorker(SelectedKategory.ID_type) != null)
                        {
                            db.RemoveKategory(SelectedKategory);
                            kategory.Remove(SelectedKategory);
                            db.Save();
                            ds.ShowMessage("Объект удален!");
                        }
                        else kategory.Remove(SelectedKategory);
                    },
                    (obj) => SelectedKategory != null));
            }
        }

        private RelayCommand saveKategory;
        public RelayCommand SaveKategory
        {
            get
            {
                return saveKategory ??
                    (saveKategory = new RelayCommand(obj =>
                    {

                        var Kategory = db.FindKategory(SelectedKategory.ID_type);
                        if (Kategory == null)
                        {
                            db.AddKategory(SelectedKategory);
                        }
                        db.Save();
                        ds.ShowMessage("Изменения сохранены!");
                    },
                    (obj) => (SelectedKategory != null) && SelectedKategory.Name.TrimEnd() != "Новый тип" && SelectedKategory.Capacity != 0 && SelectedKategory.Cost!= 0));
            }
        }
        private RelayCommand uploadPhoto;
        public RelayCommand UploadPhoto
        {
            get
            {
                return uploadPhoto ??
                    (uploadPhoto = new RelayCommand(obj =>
                    {
                        if (ds.OpenFileDialog() == true)
                        {
                            try
                            {
                                SelectedKategory.Photo = ds.FilePath;
                                ds.ShowMessage("Фото загружено!");
                            }
                            catch { ds.ShowMessage("Пожалуйста, попробуйте еще раз!"); }

                        }
                    }));
            }

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
