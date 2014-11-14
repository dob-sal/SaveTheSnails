namespace SaveTheSnails.Web.Areas.Users.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using Microsoft.AspNet.Identity;

    using AutoMapper;

    using SaveTheSnails.Data;
    using SaveTheSnails.Data.Models;
    using SaveTheSnails.Web.Areas.Users.ViewModels;
    using SaveTheSnails.Web.Controllers;

    [Authorize]
    public class ProblemController : BaseController
    {
        public ProblemController(IAppData data)
            :base(data)
        {
                
        }
        
        // GET: Users/Problem
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterProblemViewModel model)
        {

            if (model != null && ModelState.IsValid)
            {
                var userId = this.User.Identity.GetUserId();
                model.ReporterID = userId;

                var dbModel = Mapper.Map<Problem>(model);
                this.Data.Problems.Add(dbModel);
                this.Data.SaveChanges();

                return this.RedirectToAction("Register");
            }

            return this.View(model);
        }
    }
}