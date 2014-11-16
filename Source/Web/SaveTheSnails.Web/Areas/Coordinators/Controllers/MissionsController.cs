using SaveTheSnails.Data;
using SaveTheSnails.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SaveTheSnails.Web.Areas.Coordinators.Controllers
{
    public class MissionsController : BaseController
    {
        public MissionsController(IAppData data)
            : base(data)
        {
   
        }
        
        // GET: Coordinators/Missions
        public ActionResult Index()
        {
            return View();
        }

        
        
    }
}