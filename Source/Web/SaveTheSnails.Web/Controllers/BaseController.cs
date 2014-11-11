using SaveTheSnails.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SaveTheSnails.Web.Controllers
{
    public class BaseController : Controller
    {
        public BaseController(IAppData data)
        {
            this.Data = data;
        }

        protected IAppData Data { get; set; }

    }
}