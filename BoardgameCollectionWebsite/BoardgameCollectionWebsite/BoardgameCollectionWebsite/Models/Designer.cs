namespace BoardgameCollectionWebsite.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Designer")]
    public partial class Designer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Designer()
        {
            BoardgameDesigners = new HashSet<BoardgameDesigner>();
        }

        [Key]
        public int LocalDesignerID { get; set; }

        public int DesignerID { get; set; }

        [Required]
        public string DesignerName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BoardgameDesigner> BoardgameDesigners { get; set; }
    }
}
