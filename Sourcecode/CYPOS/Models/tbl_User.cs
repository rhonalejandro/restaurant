namespace cypos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_User
    {
        public long id { get; set; }

        public string name { get; set; }

        public string address { get; set; }

        public string contact { get; set; }

        public string email { get; set; }

        public string dob { get; set; }

        public string user_name { get; set; }

        public string password { get; set; }

        public string user_type { get; set; }

        public string image_name { get; set; }

        public DateTime? log_date { get; set; }
    }
}
