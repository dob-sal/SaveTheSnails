using SaveTheSnails.Data.Common.Repository;
using SaveTheSnails.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SaveTheSnails.Web.Controllers
{
    public class HomeController : Controller
    {
        private IRepository<Problem> problems;

        public HomeController(IRepository<Problem> problems)
        {
            this.problems = problems;
        }

        public ActionResult Index()
        {
            var problems = this.problems.All();
            
            return View(problems);
        }

       
    }
}