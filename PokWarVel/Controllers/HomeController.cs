using MarvelApi;
using MarvelApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PokWarVel.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string page = "", int nrPage = 1)
        {
            long show = nrPage*24;
            if (page == "")
            {
                show = 0;
            }
            else if (page == "next")
            {
                ViewBag.next = nrPage + 1;
            }
            else if (page == "prev" && nrPage >= 1)
            {
                ViewBag.prev = nrPage - 1;
            }
            
            MarvelRequester r = new MarvelRequester();
            List<Characters> info = r.GetCharacters(limit: 24, offset: show);

            return View(info);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}