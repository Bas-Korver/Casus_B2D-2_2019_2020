namespace BoardgameCollectionWebsite.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Category")]
    public partial class Category
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Category()
        {
            BoardgameCategories = new HashSet<BoardgameCategory>();
        }

        [Key]
        public int LocalCategoryID { get; set; }

        public int CategoryID { get; set; }

        [Required]
        public string CategoryName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BoardgameCategory> BoardgameCategories { get; set; }
    }
}
