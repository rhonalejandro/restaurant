namespace cypos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Category
    {
        public long id { get; set; }

        public string category_name { get; set; }

        public long? sort_order { get; set; }

        public long? back_color { get; set; }

        public long? fore_color { get; set; }

        public bool? active { get; set; }
    }
}
