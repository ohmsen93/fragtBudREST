namespace fragtBudRESTwebAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("medarbejder")]
    public partial class medarbejder
    {
        public int medarbejderID { get; set; }

        [StringLength(15)]
        public string medarbejderNavn { get; set; }

        [StringLength(15)]
        public string medarbejderEfternavn { get; set; }

        [Required]
        [StringLength(128)]
        public string AspUserID { get; set; }
    }
}
