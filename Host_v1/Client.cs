namespace Host_v1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Client")]
    public partial class Client
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Client()
        {
            Log = new HashSet<Log>();
            Pay = new HashSet<Pay>();
            Uchet = new HashSet<Uchet>();
        }

        [Key]
        public int ID_client { get; set; }

        [Required]
        [StringLength(50)]
        public string FIO { get; set; }

        [Required]
        [StringLength(20)]
        public string passport { get; set; }

        [Required]
        [StringLength(12)]
        public string number { get; set; }

        [Column(TypeName = "date")]
        public DateTime birth { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Log> Log { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pay> Pay { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Uchet> Uchet { get; set; }
    }
}
