namespace BoardgameCollectionWebsite.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BoardgameExpansion")]
    public partial class BoardgameExpansion
    {
        public int BoardgameExpansionID { get; set; }

        public int LocalBoardgameID { get; set; }

        public int LocalExpansionID { get; set; }

        public virtual BoardGame BoardGame { get; set; }

        public virtual Expansion Expansion { get; set; }
    }
}
