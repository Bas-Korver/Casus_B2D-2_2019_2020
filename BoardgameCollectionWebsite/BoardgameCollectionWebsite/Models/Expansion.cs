namespace BoardgameCollectionWebsite.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Expansion")]
    public partial class Expansion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Expansion()
        {
            BoardgameExpansions = new HashSet<BoardgameExpansion>();
        }

        [Key]
        public int LocalExpansionID { get; set; }

        public int ExpansionID { get; set; }

        [Required]
        public string ExpansionName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BoardgameExpansion> BoardgameExpansions { get; set; }
    }
}
