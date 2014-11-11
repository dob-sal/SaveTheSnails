using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using AutoMapper.QueryableExtensions;

using SaveTheSnails.Data.Common.Repository;
using SaveTheSnails.Data.Models;
using SaveTheSnails.Web.ViewModels.Home;
using SaveTheSnails.Data;

namespace SaveTheSnails.Web.Controllers
{
    public class HomeController : BaseController
    {

        public HomeController(IAppData data)
            :base(data)
        {

        }

        public ActionResult Index()
        {
            var problems = this.Data.Problems.All()
                               .Project()
                               .To<IndexProblemViewModel>();
            
            return View(problems);
        }

       
    }
}