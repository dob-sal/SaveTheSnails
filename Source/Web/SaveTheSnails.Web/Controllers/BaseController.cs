using SaveTheSnails.Data;
using SaveTheSnails.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SaveTheSnails.Web.Controllers
{
    public class BaseController : Controller
    {
        public BaseController(IAppData data)
        {
            this.Data = data;
        }

        protected IAppData Data { get; set; }

        protected AppUser CurrentUser { get; private set; }

        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {
            this.CurrentUser = this.Data.Users.All().Where(u => u.UserName == requestContext.HttpContext.User.Identity.Name).FirstOrDefault();

            return base.BeginExecute(requestContext, callback, state);
        }

    }
}