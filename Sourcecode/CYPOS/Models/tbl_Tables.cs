namespace cypos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Tables
    {
        public long id { get; set; }

        public string table_name { get; set; }

        public long? no_of_chairs { get; set; }

        public long? location_id { get; set; }
    }
}
