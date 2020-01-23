namespace BoardgameCollectionWebsite.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BoardgameFamily")]
    public partial class BoardgameFamily
    {
        public int BoardgameFamilyID { get; set; }

        public int LocalBoardgameID { get; set; }

        public int LocalFamilyID { get; set; }

        public virtual BoardGame BoardGame { get; set; }

        public virtual Family Family { get; set; }
    }
}
