namespace cypos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Company
    {
        public int id { get; set; }

        public string company_name { get; set; }

        public string company_address { get; set; }

        public string company_phone { get; set; }

        public string email { get; set; }

        public string web { get; set; }

        public string tax_no { get; set; }

        public string footer_message { get; set; }

        public string logo { get; set; }

        public DateTime? log_date { get; set; }

        public string tax_type { get; set; }

        public string tax1_name { get; set; }

        public decimal? tax1_rate { get; set; }

        public string tax2_name { get; set; }

        public decimal? tax2_rate { get; set; }

        public int? cal_method { get; set; }
    }
}
