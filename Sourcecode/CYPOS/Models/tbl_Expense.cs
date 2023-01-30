namespace cypos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Expense
    {
        [Key]
        [Column(Order = 0)]
        public long id { get; set; }

        public string expense_date { get; set; }

        public string reference_no { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long category_id { get; set; }

        public decimal? amount { get; set; }

        public string note { get; set; }

        public string created_by { get; set; }
    }
}
