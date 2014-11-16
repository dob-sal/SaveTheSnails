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


    public class MissionsController : BaseController
    {
        public MissionsController(IAppData data)
            : base(data)
        {
   
        }

        public ActionResult Schedule()
        {
            return View();
        }

        public JsonResult Read([DataSourceRequest] DataSourceRequest request)
        {
            var missions = this.Data
                                .Missions
                                .All()
                                .Project()
                                .To<MissionViewModel>();

            return Json(missions.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Create([DataSourceRequest] DataSourceRequest request, MissionViewModel mission)
        {
            if (ModelState.IsValid)
            {
                var dbMission = Mapper.Map<Mission>(mission);
                dbMission.CoordinatorID = this.Data.Coordinators.All().FirstOrDefault(c =>c.User == this.CurrentUser).Id;

                this.Data.Missions.Add(dbMission);
                this.Data.SaveChanges();
            }

            return Json(new[] { mission }.ToDataSourceResult(request, ModelState));
        }



        public ActionResult GetProblemsList()
        {
            var problems = this.Data.Problems.All().Project().To<ProblemViewModel>();

            return Json(problems, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AllMissions()
        {
            var missions = this.Data
                                .Missions
                                .All().Where(m=>m.Id == 2 )
                                .Project()
                                .To<MissionViewModel>();

            return View(missions);
        }
        
    }
}