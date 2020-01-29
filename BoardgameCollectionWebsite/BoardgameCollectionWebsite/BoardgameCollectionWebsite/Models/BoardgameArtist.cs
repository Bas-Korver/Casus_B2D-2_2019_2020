namespace BoardgameCollectionWebsite.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BoardgameArtist")]
    public partial class BoardgameArtist
    {
        public int BoardgameArtistID { get; set; }

        public int LocalBoardgameID { get; set; }

        public int LocalArtistID { get; set; }

        public virtual Artist Artist { get; set; }

        public virtual BoardGame BoardGame { get; set; }
    }
}
