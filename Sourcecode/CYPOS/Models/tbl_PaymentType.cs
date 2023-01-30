namespace cypos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_PaymentType
    {
        public long id { get; set; }

        public string payment_type { get; set; }
    }
}
