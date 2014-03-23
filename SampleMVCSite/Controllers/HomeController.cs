using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HabitRPG.NET;
using HabitRPG.NET.Models;

namespace SampleMVCSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly string _userID = ConfigurationManager.AppSettings["UserID"];
        private readonly string _apiKey = ConfigurationManager.AppSettings["APIKey"];
        private readonly HabitRPGClient _client;

        public HomeController()
        {
            _client = new HabitRPGClient("https://habitrpg.com/api/v2", _userID, _apiKey);
        }

        public ActionResult GetTasks()
        {
            return Json(_client.GetTasks(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult History()
        {
            return Json(_client.GetExportHistory(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddTestTask()
        {
            _client.AddTask(new Task
                {
                    Text = "test task",
                    Type = "todo"
                });

            return Json("", JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
