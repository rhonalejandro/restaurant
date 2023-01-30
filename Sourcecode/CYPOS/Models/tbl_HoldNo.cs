namespace cypos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_HoldNo
    {
        [Key]
        public long auto_id { get; set; }

        public string hold_id { get; set; }
    }
}
