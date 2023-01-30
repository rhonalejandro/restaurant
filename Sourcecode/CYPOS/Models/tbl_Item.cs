namespace cypos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Item
    {
        public long id { get; set; }

        public string item_code { get; set; }

        public string item_name { get; set; }

        public decimal? cost_price { get; set; }

        public decimal? selling_price { get; set; }

        public decimal? discount { get; set; }

        public long? category_id { get; set; }

        public string image_name { get; set; }

        public bool? tax_apply { get; set; }

        public bool? show_kitchen { get; set; }

        public bool? print_kot { get; set; }

        public bool? show_pos { get; set; }

        public bool? stock_item { get; set; }

        public decimal? reorder_level { get; set; }

        public bool? active { get; set; }

        public decimal? stock_quantity { get; set; }

        public long? sort_order { get; set; }

        public DateTime? log_date { get; set; }

        public DateTime? update_date { get; set; }

        public string update_by { get; set; }
    }
}
