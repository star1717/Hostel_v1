using Host_v1.Interfaces;
using Host_v1.View;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Host_v1.ViewModel
{
    class PasswordViewModel : INotifyPropertyChanged, IRequireViewIdentification
    {
        public Model1 db = new Model1();
        public ObservableCollection<Worker> workers { get; set; }
        private Worker worker;

        public PasswordViewModel()
        {
            ViewID = Guid.NewGuid();
            workers = new ObservableCollection<Worker>(db.Worker);
            worker = new Worker();
        }
        public Guid ViewID { get; }
        private string login;
        public string Login
        {
            get { return login; }
            set
            {
                login = value;
                OnPropertyChanged("Login");
            }
        }
        private RelayCommand password;
        public RelayCommand Password
        {
            get
            {
                return password ??
                    (password = new RelayCommand(obj =>
                    {
                        var passwordBox = obj as PasswordBox;
                        if (passwordBox != null)
                        {
                            var selectedUsers = workers.Where(u => u.Login.TrimEnd() == Login && u.Parol.Trim() == passwordBox.Password);
                            if (selectedUsers.Count() > 0) // если такая запись существует
                            {

                                MessageBox.Show("Добро пожаловать, " + selectedUsers.FirstOrDefault().FIO.TrimEnd() + " <3"); // говорим, что авторизовался
                                if (selectedUsers.FirstOrDefault().position.TrimEnd() == "Администратор")
                                {
                                    MainWindow1 main = new MainWindow1();
                                  
                                    WindowManager.CloseWindow(ViewID);
                                    main.DataContext = new MainViewModel1(db);
                                    main.Show();

                                }
                                else
                                {
                                    MainWindow2 main = new MainWindow2();
                                    main.DataContext =new MainViewModel2(db);
                                    main.Show();
                                    WindowManager.CloseWindow(ViewID);                                   
                                }
                            }
                        
                            else MessageBox.Show("Пожалуйста, повторите ввод логина и пароля!"); // выводим ошибку
                        }
                    }, obj=> (Login!=null && (obj as PasswordBox).Password!=null)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
