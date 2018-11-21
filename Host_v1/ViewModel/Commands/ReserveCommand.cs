using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Host_v1.ViewModel.Commands
{
    class ReserveCommand : MyCommand<ReserveViewModel>
    {
        public ReserveCommand(ReserveViewModel cvm) : base(cvm)
        {
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            if (_cvm.SelectedClient != null)
            {
                if (_cvm.SelectedNumber != null)
                {
                    if (_cvm.SelectedWorker != null)
                    {
                        if (_cvm.uchet.Date_start < _cvm.uchet.Date_finish)
                        {
                          var client = _cvm.db.Clients.Find(_cvm.SelectedClient.ID_client);
                          var number = _cvm.db.Number.Find(_cvm.SelectedNumber.ID_number);
                          var worker = _cvm.db.Worker.Find(_cvm.SelectedWorker.ID_worker);
                          var uchet = new Uchet()
                          {
                             ID_client_FK = client.ID_client,
                             ID_number_FK=number.ID_number,
                             ID_worker_FK=worker.ID_worker,
                             Date_start=_cvm.uchet.date_start,
                             Date_finish=_cvm.uchet.date_finish
                          };
                            number.ID_status_FK = 5;
                          _cvm.db.Uchet.Add(uchet);
                          _cvm.db.SaveChanges();
                          _cvm.text = "";
                          MessageBox.Show("Номер забронирован!");
                        }
                        else _cvm.text = "Период проживания указан неправильно!";
                    }
                    else _cvm.text = "Пожалуйста, выберете администратора, работающего в системе!";
                }
                else _cvm.text = "Пожалуйста, выберете номер для бронирования!";
            }
            else _cvm.text = "Пожалуйста, выберете клиента!";
        }      
    }
}
