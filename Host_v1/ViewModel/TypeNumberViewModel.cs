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
        public Model1 db;
        public ObservableCollection<Kategory> kategory { get; set; }
        public IDialogService dialog;
        public TypeNumberViewModel(Model1 db, IDialogService ds)
        {
            this.db = db;
            dialog = ds;
            kategory = new ObservableCollection<Kategory>(db.Kategory);
            SelectedKategory=db.Kategory.FirstOrDefault();
        }
        private RelayCommand uploadPhoto;
        public RelayCommand UploadPhoto
        {
            get
            {
                return uploadPhoto ??
                    (uploadPhoto = new RelayCommand(obj =>
                    {
                        if (dialog.OpenFileDialog() == true)
                        {
                            try
                            {
                                SelectedKategory.Photo = dialog.FilePath;
                                dialog.ShowMessage("Фото загружено!");
                            }
                            catch { dialog.ShowMessage("Пожалуйста, попробуйте еще раз!"); }

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
