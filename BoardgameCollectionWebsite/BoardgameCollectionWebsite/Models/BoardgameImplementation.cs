namespace BoardgameCollectionWebsite.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("BoardgameImplementation")]
    public partial class BoardgameImplementation
    {
        public int BoardgameImplementationID { get; set; }

        public int LocalBoardgameID { get; set; }

        public int LocalImplementationID { get; set; }

        public virtual BoardGame BoardGame { get; set; }

        public virtual Implementation Implementation { get; set; }
    }
}
