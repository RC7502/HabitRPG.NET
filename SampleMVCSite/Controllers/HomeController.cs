using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HabitRPG.NET;

namespace SampleMVCSite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var client = new HabitRPGClient("https://habitrpg.com/api/v2", "764ca1f0-c1c2-41f8-8d7d-ccc72d61a9b9",
                                            "e19e755e-77a8-4833-962d-68f2904da3f1");

            return Json(client.GetTasks(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult History()
        {
            var client = new HabitRPGClient("https://habitrpg.com/api/v2", "764ca1f0-c1c2-41f8-8d7d-ccc72d61a9b9",
                                "e19e755e-77a8-4833-962d-68f2904da3f1");

            return Json(client.GetExportHistory(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
