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
        [NotMapped]
        public string ServiceName
        {
            get
            {
                return Service.name;
            }
            set
            {
                Service.name = value;
                OnPropertyChanged("ServiceName");
            }
        }
        [NotMapped]
        public int Sum
        {
            get
            {
                return sum;
            }
            set
            {
                sum = value;
                OnPropertyChanged("Sum");
            }
        }
        [NotMapped]
        public DateTime Date
        {
            get
            {
                return date;
            }
            set
            {
                date = value;
                OnPropertyChanged("Date");
            }
        }
        [NotMapped]
        public string Fio
        {
            get
            {
               return Client.Fio;
            }
            set
            {
                Client.Fio = value;
                OnPropertyChanged("Fio");
            }
        }
        [NotMapped]
        public string Passport
        {
            get
            {
                return Client.Passport;
            }
            set
            {
                Client.Passport = value;
                OnPropertyChanged("Passport");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
