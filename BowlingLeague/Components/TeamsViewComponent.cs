using BowlingLeague.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingLeague.Components
{
    public class TeamsViewComponent : ViewComponent 
    {

            private IBowlersRepository repo { get; set; }

            public TeamsViewComponent(IBowlersRepository temp)
            {
                repo = temp;
            }

            public IViewComponentResult Invoke()
            {
                ViewBag.SelectedType = RouteData?.Values["team"];
                var teams = repo.Bowlers
                    .Select(x => x.TeamID);
                return View(teams);
            }
    }
}
