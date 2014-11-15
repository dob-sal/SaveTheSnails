namespace SaveTheSnails.Web.Areas.Users.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.IO;
    using System.Web;
    using System.Web.Mvc;

    using Microsoft.AspNet.Identity;

    using AutoMapper;

    using SaveTheSnails.Data;
    using SaveTheSnails.Data.Models;
    using SaveTheSnails.Web.Areas.Users.ViewModels;
    using SaveTheSnails.Web.Controllers;
    using SaveTheSnails.Web.Infrastructure.Populators;

    [Authorize]
    public class ProblemController : BaseController
    {
        private IDropDownListPopulator populator;


        public ProblemController(IAppData data, IDropDownListPopulator populator)
            :base(data)
        {
            this.populator = populator;  
        }
        
        // GET: Users/Problem
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            var registerProblemViewModel = new RegisterProblemViewModel
            {
                Categories = this.populator.GetCategories()
            };

            return View(registerProblemViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterProblemViewModel model)
        {

            if (model != null && ModelState.IsValid)
            {
                var dbProblem = Mapper.Map<Problem>(model);
                dbProblem.Reporter = this.CurrentUser;

                foreach (var picture in model.UploadedPictures)
                {
                    if (picture != null)
                    {
                        using (var memory = new MemoryStream())
                        {
                            picture.InputStream.CopyTo(memory);

                            var dbPicture = new Picture
                            {
                                File = memory.GetBuffer(),
                                FileName = picture.FileName,
                                ContentType = picture.ContentType
                            };

                            dbProblem.Pictures.Add(dbPicture);
                        }
                    }
                }

                this.Data.Problems.Add(dbProblem);
                this.Data.SaveChanges();

                return this.RedirectToAction("Register");
            }

            return this.View(model);
        }


        public ActionResult Details(int id)
        {

            var problemFromDB = this.Data.Problems.GetById(id);
            return View(problemFromDB);
        }

        [ChildActionOnly]
        public FileContentResult GetPicture(int id)
        {
            var picture = this.Data.Pictures.GetById(id);
            return picture.File != null ? new FileContentResult(picture.File, picture.ContentType) : null;
        }

        [ChildActionOnly]
        public ActionResult GetCategories()
        {
            return Json(this.populator.GetCategories(), JsonRequestBehavior.AllowGet);
        }

    }
}