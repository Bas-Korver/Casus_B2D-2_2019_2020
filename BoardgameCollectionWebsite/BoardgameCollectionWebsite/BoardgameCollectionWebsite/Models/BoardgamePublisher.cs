namespace BoardgameCollectionWebsite.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BoardgamePublisher")]
    public partial class BoardgamePublisher
    {
        public int BoardgamePublisherID { get; set; }

        public int LocalBoardgameID { get; set; }

        public int LocalPublisherID { get; set; }

        public virtual BoardGame BoardGame { get; set; }

        public virtual Publisher Publisher { get; set; }
    }
}
