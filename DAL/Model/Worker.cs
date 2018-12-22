namespace Host_v1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.CompilerServices;

    [Table("Worker")]
    public partial class Worker: INotifyPropertyChanged
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Worker()
        {
            Uchet = new HashSet<Uchet>();
        }

        [Key]
        public int ID_worker { get; set; }

        [Required]
        [StringLength(50)]
        public string FIO { get; set; }

        [Required]
        [StringLength(11)]
        public string number { get; set; }

        [Required]
        [StringLength(20)]
        public string position { get; set; }

        [Required]
        [StringLength(20)]
        public string passport { get; set; }

        [Required]
        [StringLength(50)]
        public string login { get; set; }

        [Required]
        [StringLength(50)]
        public string parol { get; set; }

        [Column(TypeName = "date")]
        public DateTime birth { get; set; }

       
        [NotMapped]
        public string Position
        {
            get { return position.TrimEnd(); }
            set
            {
                position = value;
                OnPropertyChanged("Position");
            }
        }

        [NotMapped]
        public string Login
        {
            get { return login.TrimEnd(); }
            set
            {
                login = value;
                OnPropertyChanged("Login");
            }
        }
        [NotMapped]
        public string Parol
        {
            get { return parol.TrimEnd(); }
            set
            {
                parol = value;
                OnPropertyChanged("Parol");
            }
        }

        [NotMapped]
        public string Fio
        {
            get { return FIO.TrimEnd(); }
            set
            {
                FIO = value;
                OnPropertyChanged("Fio");
            }
        }
        [NotMapped]
        public string Passport
        {
            get { return passport.TrimEnd(); }
            set
            {
                passport = value;
                OnPropertyChanged("Passport");
            }
        }
        [NotMapped]
        public string Number
        {
            get { return number; }
            set
            {
                number = value;
                OnPropertyChanged("Number");
            }
        }
        [NotMapped]
        public DateTime Birth
        {
            get { return birth; }
            set
            {
                birth = value;
                OnPropertyChanged("Birth");
            }
        }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Uchet> Uchet { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
