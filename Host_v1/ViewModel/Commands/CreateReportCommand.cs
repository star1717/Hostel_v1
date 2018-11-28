using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Host_v1.ViewModel.Commands
{
    class CreateReportCommand : MyCommand<ReportViewModel>
    {
        public CreateReportCommand(ReportViewModel cvm) : base(cvm)
        {
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            _cvm.report = null;
            foreach(var item in _cvm.uchet)
            {
              if(_cvm.SelectedDateStart<=item.Date_start && _cvm.SelectedDateFinish >= item.Date_finish && _cvm.SelectedDateFinish >= item.Date_start && _cvm.SelectedDateStart <= item.Date_finish)
              {
                    _cvm.report.Add(item);
              }
            }            
        }
    }
}
