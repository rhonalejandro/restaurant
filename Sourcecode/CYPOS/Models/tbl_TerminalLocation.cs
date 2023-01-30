namespace cypos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_TerminalLocation
    {
        public int ID { get; set; }

        [StringLength(250)]
        public string CompanyName { get; set; }

        [StringLength(150)]
        public string Branchname { get; set; }

        [StringLength(430)]
        public string Location { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(150)]
        public string Email { get; set; }

        [StringLength(150)]
        public string Web { get; set; }

        public decimal? VAT { get; set; }

        public decimal? Dis { get; set; }

        [StringLength(150)]
        public string VATRegiNo { get; set; }

        [StringLength(110)]
        public string Shopid { get; set; }

        [StringLength(450)]
        public string Footermsg { get; set; }
    }
}
