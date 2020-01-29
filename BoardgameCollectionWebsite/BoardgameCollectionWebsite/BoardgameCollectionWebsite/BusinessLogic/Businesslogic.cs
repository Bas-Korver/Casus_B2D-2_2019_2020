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