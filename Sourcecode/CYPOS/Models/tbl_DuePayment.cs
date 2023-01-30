namespace cypos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_DuePayment
    {
        public long id { get; set; }

        [StringLength(50)]
        public string payment_date { get; set; }

        public long? invoice_id { get; set; }

        public decimal? total_amount { get; set; }

        public decimal? due_amount { get; set; }

        public decimal? paid_amount { get; set; }

        public string payment_type { get; set; }

        public string customer_id { get; set; }

        public int? status { get; set; }
    }
}
