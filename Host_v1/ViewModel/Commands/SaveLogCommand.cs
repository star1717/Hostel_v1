using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Host_v1.ViewModel.Commands
{
    class SaveLogCommand : MyCommand<LogViewModel>
    {
        public SaveLogCommand(LogViewModel cvm) : base(cvm)
        {
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            if (_cvm.SelectedLog != null)
            {
                var log = _cvm.db.Log.Find(_cvm.SelectedLog.ID_line);
                if (log == null)
                {
                    _cvm.db.Log.Add(_cvm.SelectedLog);
                }

                _cvm.db.SaveChanges();
                MessageBox.Show("Изменения сохранены!");
            }
            else MessageBox.Show("Пожалуйста, выберете запись из списка!");
        }
    }
}
