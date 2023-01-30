namespace cypos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class vw_CustomerCredit
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ID { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Mobile { get; set; }

        [StringLength(250)]
        public string Address { get; set; }

        [StringLength(250)]
        public string EmailAddress { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(50)]
        public string PeopleType { get; set; }
    }
}
