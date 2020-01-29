namespace BoardgameCollectionWebsite.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BoardGame
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BoardGame()
        {
            BoardgameArtists = new HashSet<BoardgameArtist>();
            BoardgameCategories = new HashSet<BoardgameCategory>();
            BoardgameDesigners = new HashSet<BoardgameDesigner>();
            BoardgameExpansions = new HashSet<BoardgameExpansion>();
            BoardgameFamilies = new HashSet<BoardgameFamily>();
            BoardgameImplementations = new HashSet<BoardgameImplementation>();
            BoardgameIntegrations = new HashSet<BoardgameIntegration>();
            BoardgameMechanics = new HashSet<BoardgameMechanic>();
            BoardgamePublishers = new HashSet<BoardgamePublisher>();
            UserBoardgameComments = new HashSet<UserBoardgameComment>();
            UserBoardgameFavourites = new HashSet<UserBoardgameFavourite>();
            UserBoardgames = new HashSet<UserBoardgame>();
        }

        [Key]
        public int LocalBoardgameID { get; set; }

        public int BoardgameID { get; set; }

        public string Thumbnail { get; set; }

        public string Image { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int? PublicationYear { get; set; }

        public int? MinPlayers { get; set; }

        public int? MaxPlayers { get; set; }

        public int? PlayingTime { get; set; }

        public int? MaxPlayTime { get; set; }

        public int? MinPlayTime { get; set; }

        public int? MinAge { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BoardgameArtist> BoardgameArtists { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BoardgameCategory> BoardgameCategories { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BoardgameDesigner> BoardgameDesigners { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BoardgameExpansion> BoardgameExpansions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BoardgameFamily> BoardgameFamilies { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BoardgameImplementation> BoardgameImplementations { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BoardgameIntegration> BoardgameIntegrations { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BoardgameMechanic> BoardgameMechanics { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BoardgamePublisher> BoardgamePublishers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserBoardgameComment> UserBoardgameComments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserBoardgameFavourite> UserBoardgameFavourites { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserBoardgame> UserBoardgames { get; set; }
    }
}
