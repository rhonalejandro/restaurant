namespace cypos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Modifier
    {
        public long id { get; set; }

        public string name { get; set; }

        public decimal? price { get; set; }

        [StringLength(1)]
        public string price_method { get; set; }

        public string item_code { get; set; }

        public bool? print_to_kitchen { get; set; }

        public string back_color { get; set; }

        public string fore_color { get; set; }

        public long? sort_order { get; set; }
    }
}
