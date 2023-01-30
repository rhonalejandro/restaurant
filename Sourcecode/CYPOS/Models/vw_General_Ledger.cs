namespace cypos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class vw_General_Ledger
    {
        [StringLength(150)]
        public string Date { get; set; }

        public decimal? Sales { get; set; }

        [Key]
        public decimal Return { get; set; }
    }
}
