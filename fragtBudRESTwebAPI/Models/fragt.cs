namespace fragtBudRESTwebAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("fragt")]
    public partial class fragt
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public fragt()
        {
            ordre = new HashSet<ordre>();
        }

        public int fragtID { get; set; }

        public int? medarbejderID { get; set; }

        public byte? ekspress { get; set; }

        public int? afPostnr { get; set; }

        [StringLength(20)]
        public string afVej { get; set; }

        [StringLength(6)]
        public string afHusNr { get; set; }

        public int? levPostnr { get; set; }

        [StringLength(20)]
        public string levVej { get; set; }

        [StringLength(6)]
        public string levHusNr { get; set; }

        public virtual postnrBy postnrBy { get; set; }

        public virtual postnrBy postnrBy1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ordre> ordre { get; set; }
    }
}
