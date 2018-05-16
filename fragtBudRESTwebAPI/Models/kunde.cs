namespace fragtBudRESTwebAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("kunde")]
    public partial class kunde
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public kunde()
        {
            ordre = new HashSet<ordre>();
        }

        public int kundeID { get; set; }

        public int? kundeType { get; set; }

        [Required]
        [StringLength(30)]
        public string kundeNavn { get; set; }

        [Required]
        [StringLength(128)]
        public string AspUserID { get; set; }

        public virtual kundetype kundetype1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ordre> ordre { get; set; }
    }
}
