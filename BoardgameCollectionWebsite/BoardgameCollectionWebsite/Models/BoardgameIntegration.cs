namespace BoardgameCollectionWebsite.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

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
