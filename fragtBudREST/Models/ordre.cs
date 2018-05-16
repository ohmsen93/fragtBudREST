namespace fragtBudREST.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ordre")]
    public partial class ordre
    {
        public int ordreID { get; set; }

        public int? kundeID { get; set; }

        public byte Godkendt { get; set; }

        public int? fragtID { get; set; }

        public byte? Franco { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Dato { get; set; }

        public DateTime? leveringsDato { get; set; }

        [Column(TypeName = "ntext")]
        public string Beskrivelse { get; set; }

        [StringLength(32)]
        public string QR { get; set; }

        public virtual fragt fragt { get; set; }

        public virtual kunde kunde { get; set; }
    }
}
