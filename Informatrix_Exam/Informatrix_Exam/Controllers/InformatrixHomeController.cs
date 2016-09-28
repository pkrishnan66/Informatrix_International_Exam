using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Informatrix_Exam.Models;


namespace Informatrix_Exam.Controllers
{
    public class InformatrixHomeController : Controller
    {
        //
        // GET: /InformatrixHome/

        public ActionResult InformatrixHome()
        {
            return View();
        }

        public ActionResult SettledBets()
        {
            SettledBetHistory objSettledBets = new SettledBetHistory();
            return View(objSettledBets.GetSettledBetHistory());
        }

        public ActionResult UnSettledBetsUnUsual()
        {
            UnSettledBets objUnSettledBets = new UnSettledBets();
            objUnSettledBets.GetUsualHighlyUnsualBets(10);
            return View();
        }

        public ActionResult UnSettledBetsHighlyUnUsual()
        {
            UnSettledBets objUnSettledBets = new UnSettledBets();
            objUnSettledBets.GetUsualHighlyUnsualBets(30);
            return View();
        }

        public ActionResult GetMaxUnSettledBets()
        {
            UnSettledBets objUnSettledBets = new UnSettledBets();
            return View(objUnSettledBets.GetHighestRiskBets());
        }
    }
}
