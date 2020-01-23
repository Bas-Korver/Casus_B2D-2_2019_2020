namespace BoardgameCollectionWebsite.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BoardgameIntegration")]
    public partial class BoardgameIntegration
    {
        public int BoardgameIntegrationID { get; set; }

        public int LocalBoardgameID { get; set; }

        public int LocalIntegrationID { get; set; }

        public virtual BoardGame BoardGame { get; set; }

        public virtual Integration Integration { get; set; }
    }
}
