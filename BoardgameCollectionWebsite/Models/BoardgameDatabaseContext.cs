namespace BoardgameCollectionWebsite.Models
{
    using System.Data.Entity;

    public partial class BoardgameDatabaseContext : DbContext
    {
        public BoardgameDatabaseContext()
            : base("name=BoardgameDatabaseContext")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Artist> Artists { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<BoardgameArtist> BoardgameArtists { get; set; }
        public virtual DbSet<BoardgameCategory> BoardgameCategories { get; set; }
        public virtual DbSet<BoardgameDesigner> BoardgameDesigners { get; set; }
        public virtual DbSet<BoardgameExpansion> BoardgameExpansions { get; set; }
        public virtual DbSet<BoardgameFamily> BoardgameFamilies { get; set; }
        public virtual DbSet<BoardgameImplementation> BoardgameImplementations { get; set; }
        public virtual DbSet<BoardgameIntegration> BoardgameIntegrations { get; set; }
        public virtual DbSet<BoardgameMechanic> BoardgameMechanics { get; set; }
        public virtual DbSet<BoardgamePublisher> BoardgamePublishers { get; set; }
        public virtual DbSet<BoardGame> BoardGames { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Designer> Designers { get; set; }
        public virtual DbSet<Expansion> Expansions { get; set; }
        public virtual DbSet<Family> Families { get; set; }
        public virtual DbSet<Implementation> Implementations { get; set; }
        public virtual DbSet<Integration> Integrations { get; set; }
        public virtual DbSet<Mechanic> Mechanics { get; set; }
        public virtual DbSet<Publisher> Publishers { get; set; }
        public virtual DbSet<UserBoardgameComment> UserBoardgameComments { get; set; }
        public virtual DbSet<UserBoardgameFavourite> UserBoardgameFavourites { get; set; }
        public virtual DbSet<UserBoardgame> UserBoardgames { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artist>()
                .HasMany(e => e.BoardgameArtists)
                .WithRequired(e => e.Artist)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AspNetRole>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.UserBoardgameComments)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.ASPUsersID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.UserBoardgameFavourites)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.ASPUsersID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.UserBoardgames)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.ASPUsersID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BoardGame>()
                .HasMany(e => e.BoardgameArtists)
                .WithRequired(e => e.BoardGame)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BoardGame>()
                .HasMany(e => e.BoardgameCategories)
                .WithRequired(e => e.BoardGame)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BoardGame>()
                .HasMany(e => e.BoardgameDesigners)
                .WithRequired(e => e.BoardGame)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BoardGame>()
                .HasMany(e => e.BoardgameExpansions)
                .WithRequired(e => e.BoardGame)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BoardGame>()
                .HasMany(e => e.BoardgameFamilies)
                .WithRequired(e => e.BoardGame)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BoardGame>()
                .HasMany(e => e.BoardgameImplementations)
                .WithRequired(e => e.BoardGame)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BoardGame>()
                .HasMany(e => e.BoardgameIntegrations)
                .WithRequired(e => e.BoardGame)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BoardGame>()
                .HasMany(e => e.BoardgameMechanics)
                .WithRequired(e => e.BoardGame)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BoardGame>()
                .HasMany(e => e.BoardgamePublishers)
                .WithRequired(e => e.BoardGame)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BoardGame>()
                .HasMany(e => e.UserBoardgameComments)
                .WithRequired(e => e.BoardGame)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BoardGame>()
                .HasMany(e => e.UserBoardgameFavourites)
                .WithRequired(e => e.BoardGame)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BoardGame>()
                .HasMany(e => e.UserBoardgames)
                .WithRequired(e => e.BoardGame)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.BoardgameCategories)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Designer>()
                .HasMany(e => e.BoardgameDesigners)
                .WithRequired(e => e.Designer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Expansion>()
                .HasMany(e => e.BoardgameExpansions)
                .WithRequired(e => e.Expansion)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Family>()
                .HasMany(e => e.BoardgameFamilies)
                .WithRequired(e => e.Family)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Implementation>()
                .HasMany(e => e.BoardgameImplementations)
                .WithRequired(e => e.Implementation)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Integration>()
                .HasMany(e => e.BoardgameIntegrations)
                .WithRequired(e => e.Integration)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Mechanic>()
                .HasMany(e => e.BoardgameMechanics)
                .WithRequired(e => e.Mechanic)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Publisher>()
                .HasMany(e => e.BoardgamePublishers)
                .WithRequired(e => e.Publisher)
                .WillCascadeOnDelete(false);
        }
    }
}
