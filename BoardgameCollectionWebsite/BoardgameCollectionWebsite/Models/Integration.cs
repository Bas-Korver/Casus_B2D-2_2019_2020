namespace BoardgameCollectionWebsite.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Integration")]
    public partial class Integration
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Integration()
        {
            BoardgameIntegrations = new HashSet<BoardgameIntegration>();
        }

        [Key]
        public int LocalIntegrationID { get; set; }

        public int IntegrationID { get; set; }

        [Required]
        public string IntegratedBy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BoardgameIntegration> BoardgameIntegrations { get; set; }
    }
}
