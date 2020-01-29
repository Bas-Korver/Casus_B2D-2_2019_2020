namespace BoardgameCollectionWebsite.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BoardgameDesigner")]
    public partial class BoardgameDesigner
    {
        public int BoardgameDesignerID { get; set; }

        public int LocalBoardgameID { get; set; }

        public int LocalDesignerID { get; set; }

        public virtual BoardGame BoardGame { get; set; }

        public virtual Designer Designer { get; set; }
    }
}
