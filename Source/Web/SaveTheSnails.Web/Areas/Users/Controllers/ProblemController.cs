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
    using AutoMapper.QueryableExtensions;

    using SaveTheSnails.Data;
    using SaveTheSnails.Data.Models;
    using SaveTheSnails.Web.Areas.Users.ViewModels;
    using SaveTheSnails.Web.Controllers;
    using SaveTheSnails.Web.Infrastructure.Populators;
    using Kendo.Mvc.UI;
    using Kendo.Mvc.Extensions;

    [Authorize]
    public class ProblemController : BaseController
    {
        private IDropDownListPopulator populator;

        public ProblemController(IAppData data, IDropDownListPopulator populator)
            : base(data)
        {
            this.populator = populator;
        }

        // GET: Users/Problem
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult All(FilterProblemsViewModel filter)
        {
            return View(filter);
        }


        [HttpPost]
        public ActionResult ReadProblems([DataSourceRequest]DataSourceRequest request, int? category, int? region)
        {
            var problemsQuery = this.Data.Problems.All();

            if (category != null)
            {
                problemsQuery = problemsQuery.Where(t => t.CategoryID == category);
            }

            if (region != null)
            {
                problemsQuery = problemsQuery.Where(t => t.Location.RegionID == region);
            }

            var problems = problemsQuery
                            .Project()
                            .To<AllProblemsListViewModel>();

            return Json(problems.ToDataSourceResult(request));
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

                var dbPictures = this.MapPictures(model.UploadedPictures);
                dbProblem.Pictures.AddRange(dbPictures);

                this.Data.Problems.Add(dbProblem);
                this.Data.SaveChanges();

                return this.RedirectToAction("Register");
            }

            return this.View(model);
        }

        public ActionResult Details(int id)
        {

            var problem = this.Data
                .Problems
                .All()
                .Where(t => t.Id == id)
                .Project()
                .To<ProblemDetailsVewModel>()
                .FirstOrDefault();

            if (problem == null)
            {
                throw new HttpException(404, "Problem not found");
            }

            return View(problem);
        }

        public ActionResult GetCategories()
        {
            return Json(this.populator.GetCategories(), JsonRequestBehavior.AllowGet);
        }


        public ActionResult GetRegions()
        {
            return Json(this.populator.GetRegions(), JsonRequestBehavior.AllowGet);
        }

        public FileContentResult GetPicture(int id)
        {
            var picture = this.Data.Pictures.GetById(id);
            return picture.File != null ? new FileContentResult(picture.File, picture.ContentType) : null;
        }

        private ICollection<Picture> MapPictures(ICollection<HttpPostedFileBase> uploadedPictures)
        {
            ICollection<Picture> dbPictures = new List<Picture>(); ;

            foreach (var picture in uploadedPictures)
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

                        dbPictures.Add(dbPicture);
                    }
                }
            }

            return dbPictures;
        }
    }
}