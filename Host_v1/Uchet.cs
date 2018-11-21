namespace Host_v1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Uchet")]
    public partial class Uchet
    {
        [Key]
        public int ID_ychet { get; set; }

        public DateTime Date_start { get; set; }

        public DateTime Date_finish { get; set; }

        public int Pay { get; set; }

        public int ID_number_FK { get; set; }

        public int ID_worker_FK { get; set; }

        public int ID_pay_FK { get; set; }

        public int ID_client_FK { get; set; }

        public virtual Client Client { get; set; }

        public virtual Number Number { get; set; }

        public virtual Pay Pay1 { get; set; }

        public virtual Worker Worker { get; set; }
    }
}
