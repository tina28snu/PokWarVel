using MarvelApi;
using MarvelApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PokWarVel.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string searchHero, string pageS = "", int nrPageS = 1)
        {
            long show = nrPageS * 24;
            if (pageS == "")
            {
                show = 0;
            }
            else if (pageS == "next")
            {
                ViewBag.next = nrPageS + 1;
            }
            else if (pageS == "prev" && nrPageS >= 1)
            {
                ViewBag.prev = nrPageS - 1;
            }
            MarvelRequester r = new MarvelRequester();
            List<Characters> info = r.SearchCharacters(limit: 24, offset: show, SearchString: searchHero);

            //filtre
            List<Characters> trouve = new List<Characters>();

            foreach (Characters item in info)
            {
                if (item.name.Contains(searchHero))
                {
                    trouve.Add(item);
                }
            }

            return View(trouve);

            // In loc de tot foreach si return putem scrie:
            // return View(info.Where(l => l.name.Contains(searchHero)));

        }
    }
}