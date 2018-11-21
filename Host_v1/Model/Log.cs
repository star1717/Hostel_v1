namespace Host_v1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.CompilerServices;

    [Table("Log")]
    public partial class Log: INotifyPropertyChanged
    {
        [Key]
        public int ID_line { get; set; }

        public DateTime date { get; set; }

        public int sum { get; set; }

        public int ID_service_FK { get; set; }

        public int ID_client_FK { get; set; }

        public virtual Client Client { get; set; }

        public virtual Service Service { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
