namespace cypos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class vw_CustCreditReport
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long TrxID { get; set; }

        [StringLength(150)]
        public string Date { get; set; }

        public long? CustID { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(250)]
        public string OrderID { get; set; }

        public decimal? Credit { get; set; }

        [StringLength(250)]
        public string Description { get; set; }
    }
}
