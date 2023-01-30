namespace cypos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Customer
    {
        public long id { get; set; }

        public string name { get; set; }

        public string address { get; set; }

        public string city { get; set; }

        public string phone { get; set; }

        public string email { get; set; }
    }
}
