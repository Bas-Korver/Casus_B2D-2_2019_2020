namespace BoardgameCollectionWebsite.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Family")]
    public partial class Family
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Family()
        {
            BoardgameFamilies = new HashSet<BoardgameFamily>();
        }

        [Key]
        public int LocalFamilyID { get; set; }

        public int FamilyID { get; set; }

        [Required]
        public string FamilyName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BoardgameFamily> BoardgameFamilies { get; set; }
    }
}
