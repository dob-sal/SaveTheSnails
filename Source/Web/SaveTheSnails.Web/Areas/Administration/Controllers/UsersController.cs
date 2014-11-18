using Kendo.Mvc.UI;
using SaveTheSnails.Data;
using SaveTheSnails.Web.Areas.Administration.Controllers.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;

namespace SaveTheSnails.Web.Areas.Administration.Controllers
{
    using Model = SaveTheSnails.Data.Models.AppUser;
    using ViewModel = SaveTheSnails.Web.Areas.Administration.ViewModels.Users.UsersViewModel;
    
    public class UsersController : KendoGridAdministrationController
    {
        public UsersController(IAppData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        protected override IEnumerable GetData()
        {
            var users = this.Data
                                .Users
                                .All()
                                .Project()
                                .To<ViewModel>();
            return users;
        }

        protected override T GetById<T>(object id)
        {
            return this.Data.Users.GetById(id) as T;
        }

        [HttpPost]
        public ActionResult Create([DataSourceRequest]DataSourceRequest request, ViewModel model)
        {
            var dbModel = base.Create<Model>(model);
            if (dbModel != null) model.Id = dbModel.Id;
            return this.GridOperation(model, request);
        }

        //[HttpPost]
        //public ActionResult Update([DataSourceRequest]DataSourceRequest request, ViewModel model)
        //{
        //    base.Update<Model, ViewModel>(model, model.Id);
        //    return this.GridOperation(model, request);
        //}

        [HttpPost]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, ViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                this.Data.Users.Delete(model.Id);
                this.Data.SaveChanges();
            }

            return this.GridOperation(model, request);
        }
    }
}