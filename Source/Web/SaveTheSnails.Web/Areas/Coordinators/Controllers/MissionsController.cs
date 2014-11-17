namespace SaveTheSnails.Web.Areas.Coordinators.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using SaveTheSnails.Data;
    using SaveTheSnails.Web.Controllers;
    using SaveTheSnails.Web.Areas.Coordinators.ViewModels;

    using Kendo.Mvc.UI;
    using Kendo.Mvc.Extensions;
    using SaveTheSnails.Data.Models;
    using SaveTheSnails.Web.Services;
    using SaveTheSnails.Common;


    public class MissionsController : BaseController
    {
        private SchedulerMissionService missionService;

        public MissionsController(IAppData data)
            : base(data)
        {
            this.missionService = new SchedulerMissionService(this.Data, this.CurrentUser);
        }

        public ActionResult Schedule()
        {
            return View();
        }

        public JsonResult Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(missionService.GetAll().ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Create([DataSourceRequest] DataSourceRequest request, MissionViewModel mission)
        {
            if (ModelState.IsValid)
            {
                this.missionService.Insert(mission, ModelState);
            }

            return Json(new[] { mission }.ToDataSourceResult(request, ModelState));
        }

        public virtual JsonResult Update([DataSourceRequest] DataSourceRequest request, MissionViewModel meeting)
        {
            if (ModelState.IsValid)
            {
                missionService.Update(meeting, ModelState);
            }

            return Json(new[] { meeting }.ToDataSourceResult(request, ModelState));
        }

        public virtual JsonResult Destroy([DataSourceRequest] DataSourceRequest request, MissionViewModel meeting)
        {
            if (ModelState.IsValid)
            {
                missionService.Delete(meeting, ModelState);
            }

            return Json(new[] { meeting }.ToDataSourceResult(request, ModelState));
        }

        //TODO : add in Where clause if region of problem is the same with region of current user
        public ActionResult GetProblemsList()
        {
            if (User.IsInRole(GlobalConstants.AdminRole))
            {
                
            }


            var coordinatorRegion = this.Data.Coordinators.All()
                                                    .FirstOrDefault(c => c.User.UserName == this.CurrentUser.UserName).RegionID;

            var problems = this.Data.Problems.All()
                                        .Where(p => p.MissionID == null || p.Location.RegionID == coordinatorRegion)
                                        .Project().To<ProblemViewModel>();

            return Json(problems, JsonRequestBehavior.AllowGet);
        }

    }
}