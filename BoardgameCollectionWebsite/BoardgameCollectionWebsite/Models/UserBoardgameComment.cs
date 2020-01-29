namespace BoardgameCollectionWebsite.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("UserBoardgameComment")]
    public partial class UserBoardgameComment
    {
        public int UserBoardgameCommentID { get; set; }

        [Required]
        [StringLength(128)]
        public string ASPUsersID { get; set; }

        public int LocalBoardgameID { get; set; }

        [Required]
        public string BoardgameComment { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }

        public virtual BoardGame BoardGame { get; set; }
    }
}
