namespace BoardgameCollectionWebsite.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

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
