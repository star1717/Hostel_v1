using Host_v1.View;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Host_v1.ViewModel
{
    class PasswordCommand : MyCommand<PasswordViewModel>
    {
        public PasswordCommand(PasswordViewModel cvm) : base(cvm)
        {
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            
            var passwordBox = parameter as PasswordBox;
            if (passwordBox != null)
            {
                    var selectedUsers = _cvm.workers.Where(u => u.Login.TrimEnd() == _cvm.Worker.Login && u.Parol.Trim() == passwordBox.Password);
                    if (selectedUsers.Count()>0) // если такая запись существует
                    {
                    selectedUsers.FirstOrDefault().input = true;
                     MessageBox.Show("Добро пожаловать, "+selectedUsers.FirstOrDefault().FIO.TrimEnd()+" <3"); // говорим, что авторизовался
                    if (selectedUsers.FirstOrDefault().position.TrimEnd() == "Администратор")
                    {
                        MainWindow1 main = new MainWindow1(_cvm.db);
                        main.Show();
                        _cvm.CloseAction();
                    }
                    else
                    {
                        MainWindow2 main = new MainWindow2(_cvm.db);
                        main.Show();
                        _cvm.CloseAction();
                    }

                    }
                    else MessageBox.Show("Пожалуйста, повторите ввод логина и пароля!"); // выводим ошибку
            }                     
        }
    }
}
