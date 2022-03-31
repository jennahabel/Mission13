using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Mission13.Models;

namespace Mission13.Components
{
    public class TeamsViewComponent : ViewComponent
    {
        private BowlersDbContext _context { get; set; }

        public TeamsViewComponent(BowlersDbContext temp)
        {
            _context = temp;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.TeamName = RouteData?.Values["teamName"];

            var teams = _context.Teams
                .Select(x => x.TeamName)
                .Distinct()
                .OrderBy(x => x);

            return View(teams);
        }
    }
}
