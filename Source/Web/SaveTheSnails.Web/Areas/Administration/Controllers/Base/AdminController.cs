using SaveTheSnails.Data;
using SaveTheSnails.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SaveTheSnails.Web.Areas.Administration.Controllers.Base
{
    [Authorize(Roles = "Admin")]
    public abstract class AdminController : BaseController
    {
        public AdminController(IAppData data)
            : base(data)
        {

        }
    }
}