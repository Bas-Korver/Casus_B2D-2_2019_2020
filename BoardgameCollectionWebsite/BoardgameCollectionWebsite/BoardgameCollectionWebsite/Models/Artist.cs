namespace BoardgameCollectionWebsite.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Artist")]
    public partial class Artist
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Artist()
        {
            BoardgameArtists = new HashSet<BoardgameArtist>();
        }

        [Key]
        public int LocalArtistID { get; set; }

        public int ArtistID { get; set; }

        [Required]
        public string ArtistName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BoardgameArtist> BoardgameArtists { get; set; }
    }
}
