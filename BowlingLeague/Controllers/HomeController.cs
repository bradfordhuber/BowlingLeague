using BowlingLeague.Models;
using BowlingLeague.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingLeague.Controllers
{
    public class HomeController : Controller
    {
        private IBowlersRepository repo { get; set; }

        //constructor
        public HomeController(IBowlersRepository temp)
        {
            repo = temp;
        }


        public IActionResult Index(int teamnumber, int pageNum = 1)
        {
            int pageSize = 5;

            var x = new BowlersViewModel
            {
                Bowlers = repo.Bowlers
                .Where(p => p.TeamID == teamnumber || teamnumber == 1)
                .OrderBy(b => b.BowlerFirstName)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumBooks = (teamnumber == 1
                        ? repo.Bowlers.Count()
                        : repo.Bowlers.Where(x => x.TeamID == teamnumber).Count()),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };

            return View(x);
            
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
