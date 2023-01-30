namespace cypos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_ReturnItem
    {
        [Key]
        public long return_id { get; set; }

        public string return_date { get; set; }

        public string invoice_no { get; set; }

        public string customer_id { get; set; }

        public string item_code { get; set; }

        public string item_name { get; set; }

        public decimal? qty { get; set; }

        public decimal? price { get; set; }

        public decimal? total { get; set; }

        public decimal? discount_rate { get; set; }

        public decimal? discount_amount { get; set; }

        public string tax1_name { get; set; }

        public decimal? tax1_rate { get; set; }

        public decimal? tax1_amount { get; set; }

        public string tax2_name { get; set; }

        public decimal? tax2_rate { get; set; }

        public decimal? tax2_amount { get; set; }

        [StringLength(250)]
        public string note { get; set; }

        public string user_name { get; set; }

        public DateTime? logdate { get; set; }
    }
}
