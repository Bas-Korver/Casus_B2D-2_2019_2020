using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BGGConnector;
using BGGConnector.Models;
using BoardgameCollectionWebsite.Models;

namespace BoardgameCollectionWebsite.BusinessLogic
{
    public class Businesslogic
    {
        static BoardgameDatabaseContext db = new BoardgameDatabaseContext();

        public static void addBoardGame(BoardGame game)
        {
            db.BoardGames.Add(game);
            db.SaveChanges();
        }
        public static void addArtist(Artist artist)
        {
            db.Artists.Add(artist);
            db.SaveChanges();
        }
        public static void addCategory(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
        }
        public static void addDesigner(Designer designer)
        {
            db.Designers.Add(designer);
            db.SaveChanges();
        }

        public static void addExpansion(Expansion expansion)
        {
            db.Expansions.Add(expansion);
            db.SaveChanges();
        }

        public static void addFamily(Family family)
        {
            db.Families.Add(family);
            db.SaveChanges();
        }
        public static void addImplementation(Implementation implementation)
        {
            db.Implementations.Add(implementation);
            db.SaveChanges();
        }

        public static void addMechanic(Mechanic mechanic)
        {
            db.Mechanics.Add(mechanic);
            db.SaveChanges();
        }

        public static void addPublisher(Publisher publisher)
        {
            db.Publishers.Add(publisher);
            db.SaveChanges();
        }

        public static BoardGame GetBoardByID(int id)
        {
            BoardGame foundBoard;
            
            var result = from res in db.BoardGames where res.BoardgameID == id select res;
            foundBoard = result.FirstOrDefault();
            if (foundBoard == null)
            {
                BGGBoard bggBoard = BGGConnector.Connector.GetBoardById(id.ToString());
                if (bggBoard != null)
                {
                    foundBoard.BoardgameID = Int32.Parse(bggBoard.Id);
                    foundBoard.Title = bggBoard.Name[0].Value;
                    foundBoard.Thumbnail = bggBoard.Thumbnail;
                    foundBoard.PublicationYear = Int32.Parse(bggBoard.Yearpublished.Value);
                    foundBoard.PlayingTime = Int32.Parse(bggBoard.Playingtime.Value);
                    foundBoard.MinPlayTime = Int32.Parse(bggBoard.Minplaytime.Value);
                    foundBoard.MinPlayers = Int32.Parse(bggBoard.Minplayers.Value);
                    foundBoard.MaxPlayTime = Int32.Parse(bggBoard.Maxplaytime.Value);
                    foundBoard.MaxPlayers = Int32.Parse(bggBoard.Maxplayers.Value);

                    db.BoardGames.Add(foundBoard);
                    db.SaveChanges();
                    foundBoard = (from bor in db.BoardGames where bor.BoardgameID == foundBoard.BoardgameID select bor).FirstOrDefault();

                    List < Category > categories = new List<Category>();
                    List<Designer> designers = new List<Designer>();
                    List<Artist> artists = new List<Artist>();
                    List<Publisher> publishers = new List<Publisher>();
                    List<Family> families = new List<Family>();
                    List<Expansion> expansions = new List<Expansion>();
                    List<Mechanic> mechanics = new List<Mechanic>();
                    List<Implementation> implementations = new List<Implementation>();

                    foreach (Link link in bggBoard.Link)
                    {
                        if (link.Type == "boardgamecategory")
                        {
                            categories.Add(new Category() { CategoryID = Int32.Parse(link.Id), CategoryName = link.Value });
                        }
                        else if (link.Type == "boardgamedesigner")
                        {
                            designers.Add(new Designer() { DesignerID = Int32.Parse(link.Id), DesignerName = link.Value });
                        }
                        else if (link.Type == "boardgameartist")
                        {
                            artists.Add(new Artist() { ArtistID = Int32.Parse(link.Id), ArtistName = link.Value });
                        }
                        else if (link.Type == "boardgamepublisher")
                        {
                            publishers.Add(new Publisher() { PublisherID = Int32.Parse(link.Id), PublisherName = link.Value });
                        }
                        else if (link.Type == "boardgamefamily")
                        {
                            families.Add(new Family() { FamilyID = Int32.Parse(link.Id), FamilyName = link.Value });
                        }
                        else if (link.Type == "boardgameexpansion")
                        {
                            expansions.Add(new Expansion() { ExpansionID = Int32.Parse(link.Id), ExpansionName = link.Value });
                        }
                        else if (link.Type == "boardgamemechanic")
                        {
                            mechanics.Add(new Mechanic() { MechanicID = Int32.Parse(link.Id), MechanicName = link.Value });
                        }
                        else if (link.Type == "boardgameimplementation")
                        {
                            implementations.Add(new Implementation() { ImplementationID = Int32.Parse(link.Id), ImplementedBy = link.Value });
                        }
                    }
                    
                    if (categories.Count != 0)
                    {
                        foreach(Category cat in categories)
                        {
                            Category foundCategory = db.Categories.Find(cat.CategoryID);
                            if(foundCategory == null)
                            {
                                List<BGGBoard> res = BGGConnector.Connector.GetBoardsByName(cat.CategoryName, "boardgamecategory");
                                foundCategory = new Category() { CategoryID = Int32.Parse(res[0].Id), CategoryName = res[0].Name.ToString() };
                                db.Categories.Add(foundCategory);
                                db.SaveChanges();
                                foundCategory = (from findCat in db.Categories where findCat.CategoryID == cat.CategoryID select findCat).FirstOrDefault();
                            }

                            BoardgameCategory boardgameCategory = new BoardgameCategory() { Category = foundCategory, BoardGame = foundBoard };
                            db.BoardgameCategories.Add(boardgameCategory);
                            db.SaveChanges();
                        }
                    }
                    if (designers.Count != 0)
                    {
                        foreach (Designer des in designers)
                        {
                            Designer foundDesigner = db.Designers.Find(des.DesignerID);
                            if (foundDesigner == null)
                            {
                                List<BGGBoard> res = BGGConnector.Connector.GetBoardsByName(des.DesignerName, "boardgamedesigner");
                                foundDesigner = new Designer() { DesignerID = Int32.Parse(res[0].Id), DesignerName = res[0].Name.ToString() };
                                db.Designers.Add(foundDesigner);
                                db.SaveChanges();
                                foundDesigner = (from findCat in db.Designers where findCat.DesignerID == des.DesignerID select findCat).FirstOrDefault();
                            }

                            BoardgameDesigner boardgameDesigner = new BoardgameDesigner() { Designer = foundDesigner, BoardGame = foundBoard };
                            db.BoardgameDesigners.Add(boardgameDesigner);
                            db.SaveChanges();
                        }
                    }

                   
                    if (artists.Count != 0)
                    {
                        foreach (Artist art in artists)
                        {
                            Artist foundArtist = db.Artists.Find(art.ArtistID);
                            if (foundArtist == null)
                            {
                                List<BGGBoard> res = BGGConnector.Connector.GetBoardsByName(art.ArtistName, "boardgameartist");
                                foundArtist = new Artist() { ArtistID = Int32.Parse(res[0].Id), ArtistName = res[0].Name.ToString() };
                                db.Artists.Add(foundArtist);
                                db.SaveChanges();
                                foundArtist = (from findCat in db.Artists where findCat.ArtistID == art.ArtistID select findCat).FirstOrDefault();
                            }

                            BoardgameArtist boardgameArtist = new BoardgameArtist() { Artist = foundArtist, BoardGame = foundBoard };
                            db.BoardgameArtists.Add(boardgameArtist);
                            db.SaveChanges();
                        }
                    }
                    if (publishers.Count != 0)
                    {
                        foreach (Publisher pub in publishers)
                        {
                            Publisher foundPublisher = db.Publishers.Find(pub.PublisherID);
                            if (foundPublisher == null)
                            {
                                List<BGGBoard> res = BGGConnector.Connector.GetBoardsByName(pub.PublisherName, "boardgameartist");
                                foundPublisher = new Publisher() { PublisherID = Int32.Parse(res[0].Id), PublisherName = res[0].Name.ToString() };
                                db.Publishers.Add(foundPublisher);
                                db.SaveChanges();
                                foundPublisher = (from findCat in db.Publishers where findCat.PublisherID == pub.PublisherID select findCat).FirstOrDefault();
                            }

                            BoardgamePublisher boardgamePublisher = new BoardgamePublisher() { Publisher = foundPublisher, BoardGame = foundBoard };
                            db.BoardgamePublishers.Add(boardgamePublisher);
                            db.SaveChanges();
                        }
                    }
                    // TODO: Voor de rest nog doen
                    if (families.Count != 0)
                    {
                        foreach (Family fam in families)
                        {
                            Family foundFamily = db.Families.Find(fam.FamilyID);
                            if (foundFamily == null)
                            {
                                List<BGGBoard> res = BGGConnector.Connector.GetBoardsByName(fam.FamilyName, "boardgamefamily");
                                foundFamily = new Family() { FamilyID = Int32.Parse(res[0].Id), FamilyName = res[0].Name.ToString() };
                                db.Families.Add(foundFamily);
                                db.SaveChanges();
                                foundFamily = (from findCat in db.Families where findCat.FamilyID == fam.FamilyID select findCat).FirstOrDefault();
                            }

                            BoardgameFamily boardgameFamily = new BoardgameFamily() { Family = foundFamily, BoardGame = foundBoard };
                            db.BoardgameFamilies.Add(boardgameFamily);
                            db.SaveChanges();
                        }
                    }
                    if (expansions.Count != 0)
                    {
                        foreach (Expansion exp in expansions)
                        {
                            Expansion foundExpansion = db.Expansions.Find(exp.ExpansionID);
                            if (foundExpansion == null)
                            {
                                List<BGGBoard> res = BGGConnector.Connector.GetBoardsByName(exp.ExpansionName, "boardgameexpansion");
                                foundExpansion = new Expansion() { ExpansionID = Int32.Parse(res[0].Id), ExpansionName = res[0].Name.ToString() };
                                db.Expansions.Add(foundExpansion);
                                db.SaveChanges();
                                foundExpansion = (from findCat in db.Expansions where findCat.ExpansionID == exp.ExpansionID select findCat).FirstOrDefault();
                            }

                            BoardgameExpansion boardgameExpansion = new BoardgameExpansion() { Expansion = foundExpansion, BoardGame = foundBoard };
                            db.BoardgameExpansions.Add(boardgameExpansion);
                            db.SaveChanges();
                        }
                    }
                    if (mechanics.Count != 0)
                    {
                        foreach (Mechanic mech in mechanics)
                        {
                            Mechanic foundExpansion = db.Mechanics.Find(mech.MechanicID);
                            if (foundExpansion == null)
                            {
                                List<BGGBoard> res = BGGConnector.Connector.GetBoardsByName(mech.MechanicName, "boardgameexpansion");
                                foundExpansion = new Mechanic() { MechanicID = Int32.Parse(res[0].Id), MechanicName = res[0].Name.ToString() };
                                db.Mechanics.Add(foundExpansion);
                                db.SaveChanges();
                                foundExpansion = (from findCat in db.Mechanics where findCat.MechanicID == mech.MechanicID select findCat).FirstOrDefault();
                            }

                            BoardgameMechanic boardgameMechanic = new BoardgameMechanic() { Mechanic = foundExpansion, BoardGame = foundBoard };
                            db.BoardgameMechanics.Add(boardgameMechanic);
                            db.SaveChanges();
                        }
                    }
                    if (implementations.Count != 0)
                    {
                        foreach (Implementation imp in implementations)
                        {
                            Implementation foundImplementation = db.Implementations.Find(imp.ImplementationID);
                            if (foundImplementation == null)
                            {
                                List<BGGBoard> res = BGGConnector.Connector.GetBoardsByName(imp.ImplementedBy, "boardgameexpansion");
                                foundImplementation = new Implementation() { ImplementationID = Int32.Parse(res[0].Id), ImplementedBy = res[0].Name.ToString() };
                                db.Implementations.Add(foundImplementation);
                                db.SaveChanges();
                                foundImplementation = (from findCat in db.Implementations where findCat.ImplementationID == imp.ImplementationID select findCat).FirstOrDefault();
                            }

                            BoardgameImplementation boardgameImplementation = new BoardgameImplementation() { Implementation = foundImplementation, BoardGame = foundBoard };
                            db.BoardgameImplementations.Add(boardgameImplementation);
                            db.SaveChanges();
                        }
                    }

                    
                    return foundBoard;
                }
            }
            return null;
        }

        public static List<BoardGame> getAllBoardgames()
        {
            var resultDB = db.BoardGames.ToList();
            List<BoardGame> games = resultDB;

            List<BGGBoard> boards = BGGConnector.Connector.GetBoardsByName(" ", "boardgame");

            foreach (BGGBoard board in boards)
            {
                bool boardInDB = false;
                int round = 0;
                while (!boardInDB)
                {
                    if (games[round].BoardgameID == Int32.Parse(board.Id))
                    {
                        boardInDB = true;
                    }
                }
                if (!boardInDB)
                {
                    BoardGame boardGame = new BoardGame();
                    boardGame.BoardgameID = Int32.Parse(board.Id);
                    boardGame.Title = board.Name[0].Value;
                    boardGame.PublicationYear = Int32.Parse(board.Yearpublished.Value);
                    games.Add(boardGame);
                }

            }
            return games;
        }





        public static List<Artist> getAllArtists()
        {
            var resultDB = db.Artists.ToList();
            List<Artist> games = resultDB;

            List<BGGBoard> boards = BGGConnector.Connector.GetBoardsByName(" ", "boardgameartist");

            foreach (BGGBoard board in boards)
            {
                bool boardInDB = false;
                int round = 0;
                while (!boardInDB)
                {
                    if (games[round].ArtistID == Int32.Parse(board.Id))
                    {
                        boardInDB = true;
                    }
                }
                if (!boardInDB)
                {
                    Artist boardGame = new Artist();
                    boardGame.ArtistID = Int32.Parse(board.Id);
                    boardGame.ArtistName = board.Name[0].Value;
                    games.Add(boardGame);
                }

            }
            return games;
        }

        public static List<Category> getAllCategories()
        {
            var resultDB = db.Categories.ToList();
            List<Category> games = resultDB;

            List<BGGBoard> boards = BGGConnector.Connector.GetBoardsByName(" ", "boardgamecategory");

            foreach (BGGBoard board in boards)
            {
                bool boardInDB = false;
                int round = 0;
                while (!boardInDB)
                {
                    if (games[round].CategoryID == Int32.Parse(board.Id))
                    {
                        boardInDB = true;
                    }
                }
                if (!boardInDB)
                {
                    Category boardGame = new Category();
                    boardGame.CategoryID = Int32.Parse(board.Id);
                    boardGame.CategoryName = board.Name[0].Value;
                    games.Add(boardGame);
                }

            }
            return games;
        }

        public static List<Designer> getAllDesigners()
        {
            var resultDB = db.Designers.ToList();
            List<Designer> games = resultDB;

            List<BGGBoard> boards = BGGConnector.Connector.GetBoardsByName(" ", "boardgamedesigner");

            foreach (BGGBoard board in boards)
            {
                bool boardInDB = false;
                int round = 0;
                while (!boardInDB)
                {
                    if (games[round].DesignerID == Int32.Parse(board.Id))
                    {
                        boardInDB = true;
                    }
                }
                if (!boardInDB)
                {
                    Designer boardGame = new Designer();
                    boardGame.DesignerID = Int32.Parse(board.Id);
                    boardGame.DesignerName = board.Name[0].Value;
                    games.Add(boardGame);
                }

            }
            return games;
        }

        public static List<Expansion> getAllExpansions()
        {
            var resultDB = db.Expansions.ToList();
            List<Expansion> games = resultDB;

            List<BGGBoard> boards = BGGConnector.Connector.GetBoardsByName(" ", "boardgameexpansion");

            foreach (BGGBoard board in boards)
            {
                bool boardInDB = false;
                int round = 0;
                while (!boardInDB)
                {
                    if (games[round].ExpansionID == Int32.Parse(board.Id))
                    {
                        boardInDB = true;
                    }
                }
                if (!boardInDB)
                {
                    Expansion boardGame = new Expansion();
                    boardGame.ExpansionID = Int32.Parse(board.Id);
                    boardGame.ExpansionName = board.Name[0].Value;
                    games.Add(boardGame);
                }

            }
            return games;
        }

        public static List<Family> getAllFamilies()
        {
            var resultDB = db.Families.ToList();
            List<Family> games = resultDB;

            List<BGGBoard> boards = BGGConnector.Connector.GetBoardsByName(" ", "boardgamefamily");

            foreach (BGGBoard board in boards)
            {
                bool boardInDB = false;
                int round = 0;
                while (!boardInDB)
                {
                    if (games[round].FamilyID == Int32.Parse(board.Id))
                    {
                        boardInDB = true;
                    }
                }
                if (!boardInDB)
                {
                    Family boardGame = new Family();
                    boardGame.FamilyID = Int32.Parse(board.Id);
                    boardGame.FamilyName = board.Name[0].Value;
                    games.Add(boardGame);
                }

            }
            return games;
        }


        public static List<Mechanic> getAllMechanics()
        {
            var resultDB = db.Mechanics.ToList();
            List<Mechanic> games = resultDB;

            List<BGGBoard> boards = BGGConnector.Connector.GetBoardsByName(" ", "boardgamemechanic");

            foreach (BGGBoard board in boards)
            {
                bool boardInDB = false;
                int round = 0;
                while (!boardInDB)
                {
                    if (games[round].MechanicID == Int32.Parse(board.Id))
                    {
                        boardInDB = true;
                    }
                }
                if (!boardInDB)
                {
                    Mechanic boardGame = new Mechanic();
                    boardGame.MechanicID = Int32.Parse(board.Id);
                    boardGame.MechanicName = board.Name[0].Value;
                    games.Add(boardGame);
                }

            }
            return games;
        }

        public static List<Implementation> getAllImplementations()
        {
            var resultDB = db.Implementations.ToList();
            List<Implementation> games = resultDB;

            List<BGGBoard> boards = BGGConnector.Connector.GetBoardsByName(" ", "boardgameimplementation");

            foreach (BGGBoard board in boards)
            {
                bool boardInDB = false;
                int round = 0;
                while (!boardInDB)
                {
                    if (games[round].ImplementationID == Int32.Parse(board.Id))
                    {
                        boardInDB = true;
                    }
                }
                if (!boardInDB)
                {
                    Implementation boardGame = new Implementation();
                    boardGame.ImplementationID = Int32.Parse(board.Id);
                    boardGame.ImplementedBy = board.Yearpublished.Value;
                    games.Add(boardGame);
                }

            }
            return games;
        }

        public static List<Publisher> getAllPublishers()
        {
            var resultDB = db.Publishers.ToList();
            List<Publisher> games = resultDB;

            List<BGGBoard> boards = BGGConnector.Connector.GetBoardsByName(" ", "boardgamepublisher");

            foreach (BGGBoard board in boards)
            {
                bool boardInDB = false;
                int round = 0;
                while (!boardInDB)
                {
                    if (games[round].PublisherID == Int32.Parse(board.Id))
                    {
                        boardInDB = true;
                    }
                }
                if (!boardInDB)
                {
                    Publisher boardGame = new Publisher();
                    boardGame.PublisherID = Int32.Parse(board.Id);
                    boardGame.PublisherName = board.Name[0].Value;
                    games.Add(boardGame);
                }

            }
            return games;
        }

        public static List<BoardGame> GetBoardsByName(string name)
        {
            var resultDB = from res in db.BoardGames where res.Title.Contains(name) select res;
            List<BoardGame> games = resultDB.ToList();

            List<BGGBoard> boards = BGGConnector.Connector.GetBoardsByName(name, "boardgame");

            foreach (BGGBoard board in boards)
            {
                bool boardInDB = false;
                int round = 0;
                while (!boardInDB)
                {
                    if (games[round].BoardgameID == Int32.Parse(board.Id))
                    {
                        boardInDB = true;
                    }
                }
                if (!boardInDB)
                {
                    BoardGame boardGame = new BoardGame();
                    boardGame.BoardgameID = Int32.Parse(board.Id);
                    boardGame.Title = board.Name[0].Value;
                    boardGame.PublicationYear = Int32.Parse(board.Yearpublished.Value);
                    games.Add(boardGame);
                }

            }
            return games;
        }

        public static List<BoardGame> GetBoardsByAmountPlayers(int amountOfPlayers)
        {
            var result = from res in db.BoardGames where res.MinPlayers >= amountOfPlayers select res;
            List<BoardGame> games = result.ToList();
            return games;
        }
        public static List<BoardGame> GetBoardsByMinAge(int minAge)
        {
            var result = from res in db.BoardGames where res.MinAge == minAge select res;
            List<BoardGame> games = result.ToList();
            return games;
        }

        public static void AddBoardToFavorites(BoardGame board, string userID)
        {
            var result = from netUser in db.AspNetUsers where netUser.Id == userID select netUser;
            AspNetUser user = result.FirstOrDefault();
            UserBoardgameFavourite newFavorite = new UserBoardgameFavourite();
            newFavorite.BoardGame = board;
            newFavorite.AspNetUser = user;
            db.UserBoardgameFavourites.Add(newFavorite);
            db.SaveChanges();
        }
        public static void RemoveBoardFromFavorites(int boardID, string userID)
        {
            var result = from netUser in db.UserBoardgameFavourites where netUser.ASPUsersID == userID && netUser.LocalBoardgameID == boardID select netUser;
            UserBoardgameFavourite newFavorite = result.FirstOrDefault();
            db.UserBoardgameFavourites.Remove(newFavorite);
            db.SaveChanges();
        }
        public static void AddNote(UserBoardgameComment comment, string userID)
        {
            var result = from netUser in db.AspNetUsers where netUser.Id == userID select netUser;
            AspNetUser user = result.FirstOrDefault();
            user.UserBoardgameComments.Add(comment);
            db.SaveChanges();
        }
        public static void ChangeNote(UserBoardgameComment comment, string userID)
        {
            db.Entry(comment).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
        public static void RemoveNote(UserBoardgameComment comment, string userID)
        {
            db.UserBoardgameComments.Remove(comment);
            db.SaveChanges();
        }

        public static void AddBoardToCompareList(BoardGame board)
        {
            // ??? HOE AANPAKKEN ???
        }
        public static void RemoveBoardFromCompareList(BoardGame board)
        {
            // ??? HOE AANPAKKEN ???
        }
        public static void AddBoardToMyGames(UserBoardgame board, string userID)
        {
            var result = from netUser in db.AspNetUsers where netUser.Id == userID select netUser;
            AspNetUser user = result.FirstOrDefault();
            user.UserBoardgames.Add(board);
        }
        public static void RemoveBoardFromMyGames(UserBoardgame board, string userID)
        {
            var result = from netUser in db.AspNetUsers where netUser.Id == userID select netUser;
            AspNetUser user = result.FirstOrDefault();
            user.UserBoardgames.Remove(board);
        }
    }
}