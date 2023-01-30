namespace cypos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Purchase
    {
        public long id { get; set; }

        public string purchase_date { get; set; }

        public string ref_no { get; set; }

        public long? supplier_id { get; set; }

        public long? product_id { get; set; }

        public decimal? quantity { get; set; }

        public decimal? price { get; set; }

        public decimal? amount { get; set; }

        public string purchase_type { get; set; }

        public int? status { get; set; }
    }
}
