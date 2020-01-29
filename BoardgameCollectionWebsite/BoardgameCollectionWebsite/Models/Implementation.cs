namespace BoardgameCollectionWebsite.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Implementation")]
    public partial class Implementation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Implementation()
        {
            BoardgameImplementations = new HashSet<BoardgameImplementation>();
        }

        [Key]
        public int LocalImplementationID { get; set; }

        public int ImplementationID { get; set; }

        [Required]
        public string ImplementedBy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BoardgameImplementation> BoardgameImplementations { get; set; }
    }
}
