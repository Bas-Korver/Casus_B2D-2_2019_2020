using BoardgameCollectionWebsite.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace BoardgameCollectionWebsite.Controllers
{
    public class BoardGamesController : Controller
    {
        private BoardgameDatabaseContext db = new BoardgameDatabaseContext();

        // GET: BoardGames][
        public ActionResult Index(string gameTitle = "",
                                  string gameDescription = "",
                                  string onePlayerCheckbox = "",
                                  string twoPlayerCheckbox = "",
                                  string threeFourPlayerCheckbox = "",
                                  string fivePlusPlayerCheckbox = "",
                                  string zeroToTwelveCheckbox = "",
                                  string thirteenToEighteenCheckbox = "",
                                  string eighteenPlusCheckbox = "",
                                  string zeroToFifteenCheckbox = "",
                                  string fifteenToThirtyCheckbox = "",
                                  string thirtyToSixtyCheckbox = "",
                                  string sixtyPlusCheckbox = "")
        {
            List<BoardGame> allGames = db.BoardGames.ToList();
            List<BoardGame> matchingGames = new List<BoardGame>();

            if (gameTitle.Length != 0 ^ gameDescription.Length != 0)
            {
                foreach (var boardGame in allGames)
                {
                    if (gameTitle.Length != 0 && boardGame.Title.ToLower().Contains(gameTitle.ToLower()))
                    {
                        matchingGames.Add(boardGame);
                    }
                    else if (gameDescription.Length != 0 && boardGame.Description.ToLower().Contains(gameDescription.ToLower()))
                    {
                        matchingGames.Add(boardGame);
                    }
                }

                return View(matchingGames);
            }
            else
            {
                if (onePlayerCheckbox == "on")
                {
                    foreach (var boardGame in allGames)
                    {
                        if (boardGame.MinPlayers == 1)
                        {
                            matchingGames.Add(boardGame);
                        }
                    }
                    return View(matchingGames);
                }
                if (twoPlayerCheckbox == "on")
                {
                    foreach (var boardGame in allGames)
                    {
                        if (boardGame.MinPlayers == 2)
                        {
                            matchingGames.Add(boardGame);
                        }
                    }
                    return View(matchingGames);
                }
                if (threeFourPlayerCheckbox == "on")
                {
                    foreach (var boardGame in allGames)
                    {
                        if (boardGame.MinPlayers == 3 ^ boardGame.MinPlayers == 4)
                        {
                            matchingGames.Add(boardGame);
                        }
                    }
                    return View(matchingGames);
                }
                if (fivePlusPlayerCheckbox == "on")
                {
                    foreach (var boardGame in allGames)
                    {
                        if (boardGame.MinPlayers > 4)
                        {
                            matchingGames.Add(boardGame);
                        }
                    }
                    return View(matchingGames);
                }
                if (zeroToTwelveCheckbox == "on")
                {
                    foreach (var boardGame in allGames)
                    {
                        if (boardGame.MinAge > 0 && boardGame.MinAge < 13)
                        {
                            matchingGames.Add(boardGame);
                        }
                    }
                    return View(matchingGames);
                }
                if (thirteenToEighteenCheckbox == "on")
                {
                    foreach (var boardGame in allGames)
                    {
                        if (boardGame.MinAge > 12 && boardGame.MinAge < 18)
                        {
                            matchingGames.Add(boardGame);
                        }
                    }
                    return View(matchingGames);
                }
                if (eighteenPlusCheckbox == "on")
                {
                    foreach (var boardGame in allGames)
                    {
                        if (boardGame.MinAge > 17)
                        {
                            matchingGames.Add(boardGame);
                        }
                    }
                    return View(matchingGames);
                }
                if (zeroToFifteenCheckbox == "on")
                {
                    foreach (var boardGame in allGames)
                    {
                        if (boardGame.MinPlayTime >= 0 && boardGame.MinPlayTime <= 15)
                        {
                            matchingGames.Add(boardGame);
                        }
                    }
                    return View(matchingGames);
                }
                if (fifteenToThirtyCheckbox == "on")
                {
                    foreach (var boardGame in allGames)
                    {
                        if (boardGame.MinPlayTime >= 15 && boardGame.MinPlayTime <= 30)
                        {
                            matchingGames.Add(boardGame);
                        }
                    }
                    return View(matchingGames);
                }
                if (thirtyToSixtyCheckbox == "on")
                {
                    foreach (var boardGame in allGames)
                    {
                        if (boardGame.MinPlayTime >= 30 && boardGame.MinPlayTime <= 60)
                        {
                            matchingGames.Add(boardGame);
                        }
                    }
                    return View(matchingGames);
                }
                if (sixtyPlusCheckbox == "on")
                {
                    foreach (var boardGame in allGames)
                    {
                        if (boardGame.MinPlayTime >= 60)
                        {
                            matchingGames.Add(boardGame);
                        }
                    }
                    return View(matchingGames);
                }
            }
            return View(allGames);
        }

        // GET: BoardGames/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoardGame boardGame = db.BoardGames.SingleOrDefault(m => m.BoardgameID == id);
            if (boardGame == null)
            {
                return HttpNotFound();
            }
            return View(boardGame);
        }

        // GET: BoardGames/Compare/5
        public ActionResult Compare()
        {
            string urlParams = Request.QueryString["gtc"];

            if (urlParams.Length == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            List<int> gamesToCompare = urlParams.Split(';').Select(Int32.Parse).ToList();
            List<BoardGame> boardGames = new List<BoardGame>();

            foreach (var game in gamesToCompare)
            {
                var game1 = game;
                BoardGame boardGame = db.BoardGames.SingleOrDefault(m => m.BoardgameID == game1);
                boardGames.Add(boardGame);
            }

            return View(boardGames);

        }

        // GET: BoardGames/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BoardGames/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LocalBoardgameID,BoardgameID,Thumbnail,Image,Title,Description,PublicationYear,MinPlayers,MaxPlayers,PlayingTime,MaxPlayTime,MinPlayTime,MinAge")] BoardGame boardGame)
        {
            if (ModelState.IsValid)
            {
                db.BoardGames.Add(boardGame);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(boardGame);
        }

        // GET: BoardGames/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoardGame boardGame = db.BoardGames.Find(id);
            if (boardGame == null)
            {
                return HttpNotFound();
            }
            return View(boardGame);
        }

        // POST: BoardGames/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LocalBoardgameID,BoardgameID,Thumbnail,Image,Title,Description,PublicationYear,MinPlayers,MaxPlayers,PlayingTime,MaxPlayTime,MinPlayTime,MinAge")] BoardGame boardGame)
        {
            if (ModelState.IsValid)
            {
                db.Entry(boardGame).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(boardGame);
        }

        // GET: BoardGames/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoardGame boardGame = db.BoardGames.Find(id);
            if (boardGame == null)
            {
                return HttpNotFound();
            }
            return View(boardGame);
        }

        // POST: BoardGames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BoardGame boardGame = db.BoardGames.Find(id);
            db.BoardGames.Remove(boardGame);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
