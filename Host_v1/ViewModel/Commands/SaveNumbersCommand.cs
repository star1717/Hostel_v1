﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Host_v1.ViewModel.Commands
{
    class SaveNumbersCommand : MyCommand<NumbersViewModel>
    {
        public SaveNumbersCommand(NumbersViewModel cvm) : base(cvm)
        {
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            //if (_cvm.SelectedClient != null)
            //{
            //    var client = _cvm.db.Clients.Find(_cvm.SelectedClient.ID_client);
            //    if (client != null)
            //    {
            //        client.FIO = client.Fio;
            //        client.number = client.Number;
            //        client.passport = client.Passport;
            //        client.birth = client.Birth;
            //    }
            //    else if (_cvm.SelectedClient != null) _cvm.db.Clients.Add(_cvm.SelectedClient);
            //    _cvm.db.SaveChanges();
            //    MessageBox.Show("Изменения сохранены!");
            //}
            //else MessageBox.Show("Пожалуйста, выберете клиента из списка!");
        }
    }
}