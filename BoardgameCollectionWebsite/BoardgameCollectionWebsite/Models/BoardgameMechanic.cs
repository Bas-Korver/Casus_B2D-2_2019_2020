namespace BoardgameCollectionWebsite.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BoardgameMechanic")]
    public partial class BoardgameMechanic
    {
        public int BoardgameMechanicID { get; set; }

        public int LocalBoardgameID { get; set; }

        public int LocalMechanicID { get; set; }

        public virtual BoardGame BoardGame { get; set; }

        public virtual Mechanic Mechanic { get; set; }
    }
}
