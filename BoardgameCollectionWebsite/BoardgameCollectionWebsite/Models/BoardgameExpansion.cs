namespace BoardgameCollectionWebsite.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

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
