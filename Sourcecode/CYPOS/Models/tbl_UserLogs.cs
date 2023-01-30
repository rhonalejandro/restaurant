namespace cypos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_UserLogs
    {
        public long id { get; set; }

        [StringLength(150)]
        public string user_name { get; set; }

        [StringLength(50)]
        public string log_type { get; set; }

        [Column(TypeName = "date")]
        public DateTime? log_date { get; set; }

        public TimeSpan? log_time { get; set; }

        public int? status { get; set; }
    }
}
