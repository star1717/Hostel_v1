namespace Host_v1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Log")]
    public partial class Log
    {
        [Key]
        public int ID_line { get; set; }

        public DateTime date { get; set; }

        public int sum { get; set; }

        public int ID_service_FK { get; set; }

        public int ID_client_FK { get; set; }

        public virtual Client Client { get; set; }

        public virtual Service Service { get; set; }
    }
}
