namespace cypos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_InvoiceDetail
    {
        [Key]
        public long detail_id { get; set; }

        public long? header_id { get; set; }

        public string invoice_date { get; set; }

        public string invoice_time { get; set; }

        [StringLength(150)]
        public string item_code { get; set; }

        [StringLength(250)]
        public string item_name { get; set; }

        public decimal? qty { get; set; }

        public decimal? selling_price { get; set; }

        public decimal? total { get; set; }

        public decimal? discount { get; set; }

        public decimal? discount_amount { get; set; }

        public decimal? net_amount { get; set; }

        public decimal? profit { get; set; }

        public bool? tax_apply { get; set; }

        public bool? show_kitchen { get; set; }

        public DateTime? log_date { get; set; }
    }
}
