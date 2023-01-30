namespace cypos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_ItemNo
    {
        [Key]
        public long auto_id { get; set; }

        public string item_no { get; set; }
    }
}
