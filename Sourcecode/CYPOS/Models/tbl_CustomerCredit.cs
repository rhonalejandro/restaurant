namespace cypos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_CustomerCredit
    {
        [Key]
        [Column(Order = 0)]
        public long ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long CustID { get; set; }

        [StringLength(250)]
        public string OrderID { get; set; }

        [StringLength(150)]
        public string Date { get; set; }

        public decimal? Credit { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        public DateTime? Logtime { get; set; }
    }
}
