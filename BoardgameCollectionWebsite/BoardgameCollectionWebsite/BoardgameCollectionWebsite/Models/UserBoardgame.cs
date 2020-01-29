namespace BoardgameCollectionWebsite.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UserBoardgame
    {
        [Key]
        public int UserBoardgamesID { get; set; }

        [Required]
        [StringLength(128)]
        public string ASPUsersID { get; set; }

        public int LocalBoardgameID { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }

        public virtual BoardGame BoardGame { get; set; }
    }
}
