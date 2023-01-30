namespace cypos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_InvoiceHeader
    {
        [Key]
        public long invoice_id { get; set; }

        public int? order_type { get; set; }

        public string invoice_no { get; set; }

        public string invoice_date { get; set; }

        public string invoice_time { get; set; }

        public long? table_id { get; set; }

        public long? no_of_guests { get; set; }

        public long? waiter_id { get; set; }

        [Required]
        public string customer_id { get; set; }

        [Required]
        public string payment_type { get; set; }

        public decimal? payment_amount { get; set; }

        public decimal? paid_amount { get; set; }

        public decimal? change_amount { get; set; }

        public decimal? due_amount { get; set; }

        public decimal? discount_rate { get; set; }

        public decimal? discount_amount { get; set; }

        public string tax1_name { get; set; }

        public decimal? tax1_rate { get; set; }

        public decimal? tax1_amount { get; set; }

        public string tax2_name { get; set; }

        public decimal? tax2_rate { get; set; }

        public decimal? tax2_amount { get; set; }

        public decimal? sc_rate { get; set; }

        public decimal? sc_charge { get; set; }

        public string note { get; set; }

        [Required]
        public string user_name { get; set; }

        public DateTime? log_date { get; set; }
    }
}
