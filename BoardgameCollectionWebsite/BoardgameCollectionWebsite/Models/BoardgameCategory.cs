namespace BoardgameCollectionWebsite.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BoardgameCategory")]
    public partial class BoardgameCategory
    {
        public int BoardgameCategoryID { get; set; }

        public int LocalBoardgameID { get; set; }

        public int LocalCategoryID { get; set; }

        public virtual BoardGame BoardGame { get; set; }

        public virtual Category Category { get; set; }
    }
}
