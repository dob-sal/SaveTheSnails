using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using AutoMapper.QueryableExtensions;

using SaveTheSnails.Data.Common.Repository;
using SaveTheSnails.Data.Models;
using SaveTheSnails.Web.ViewModels.Home;

namespace SaveTheSnails.Web.Controllers
{
    public class HomeController : BaseController
    {
        private IRepository<Problem> problems;

        public HomeController(IRepository<Problem> problems)
        {
            this.problems = problems;
        }

        public ActionResult Index()
        {
            var problems = this.problems.All()
                               .Project()
                               .To<IndexProblemViewModel>();
            
            return View(problems);
        }

       
    }
}