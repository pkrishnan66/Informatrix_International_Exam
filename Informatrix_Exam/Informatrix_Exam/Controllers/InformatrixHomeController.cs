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

        public ActionResult SettledBets()
        {
            UnSettledBets obj = new UnSettledBets();
            obj.GetMidLevelStake();
            return View(obj.GetHighestRiskBets());
        }

    }
}
