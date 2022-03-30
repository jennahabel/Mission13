using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission13.Models;

namespace Mission13.Controllers
{
    public class HomeController : Controller
    {
                                                                //private IBowlersRepository _repo { get; set; }

                                                                //public HomeController(IBowlersRepository temp)
                                                                //{
                                                                //_repo = temp;
                                                                //}
        private BowlersDbContext _context { get; set; }


        //Constructor
        public HomeController(BowlersDbContext temp)
        {
            _context = temp;
        }

        //Index Page
        public IActionResult Index()
        {
            return View();
        }

        //List of Bowlers
        public IActionResult ShowBowler()
        {
                                                                    //var player = _repo.Bowlers.ToList();
            var bowler = _context.Bowlers
                .Include(x => x.Teams)
                .OrderBy(x => x.BowlerFirstName)
                .ToList();

            return View(bowler);
        }

        //Add a Bowler
        [HttpGet]
        public IActionResult AddBowler()
        {
            ViewBag.Team = _context.Teams.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult AddBowler(Bowler b)
        {

            if (!ModelState.IsValid)
            {
                ViewBag.Team = _context.Teams.ToList();

                return View(b);
            }

            b.BowlerId = (_context.Bowlers.Max(b => b.BowlerId)) + 1;
            _context.Add(b);
            _context.SaveChanges();

            return View("Confirmation", b);
            
        }

        //Edit a Bowler
        public IActionResult Edit(int bowlerid)
        {
            ViewBag.Team = _context.Teams.ToList();

            var bowl = _context.Bowlers.Single(x => x.BowlerId == bowlerid);

            return View("AddBowler", bowl);
        }

        [HttpPost]
        public IActionResult Edit(Bowler b)
        {
            _context.Update(b);
            _context.SaveChanges();

            return RedirectToAction("ShowBowler");
        }


        //Delete a Bowler
        [HttpGet]
        public IActionResult Delete(int bowlerid)
        {
            var bowl = _context.Bowlers.Single(x => x.BowlerId == bowlerid);

            return View(bowl);
        }

        [HttpPost]
        public IActionResult Delete(Bowler b)
        {
            _context.Bowlers.Remove(b);
            _context.SaveChanges();

            return RedirectToAction("ShowBowler");
        }

    }
}
