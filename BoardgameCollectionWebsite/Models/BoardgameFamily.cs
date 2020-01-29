namespace BoardgameCollectionWebsite.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

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
